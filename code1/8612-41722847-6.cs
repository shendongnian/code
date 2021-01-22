    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ExecutionForwarder
    {
    	public class ProcessExecutionWithOutputCapture
    	{
    		// ************************************************************************
    		public class ProcessWithOutputCaptureResult
    		{
    			public string Output { get; internal set; }
    			private string _error;
    
    			public string Error
    			{
    				get
    				{
    					if (String.IsNullOrEmpty(_error))
    					{
    						return _error;
    					}
    
    					return Exception?.ToString();
    				}
    				internal set { _error = value; }
    			}
    			public bool HasTimeout { get; internal set; }
    			public int ExitCode { get; internal set; }
    			public Exception Exception { get; internal set; }
    
    			public bool HasSucceded => !HasTimeout && Exception == null;
    
    			public static ProcessWithOutputCaptureResult CreateExpiredOne()
    			{
    				return new ProcessWithOutputCaptureResult() { HasTimeout = true, Output = null, Error = null };
    			}
    
    			public static ProcessWithOutputCaptureResult CreateOne(int exitCode, string output, string error)
    			{
    				return new ProcessWithOutputCaptureResult() { ExitCode = exitCode, Output = output, Error = error };
    			}
    
    			public static ProcessWithOutputCaptureResult CreateOneWithException(Exception exception)
    			{
    				return new ProcessWithOutputCaptureResult() { Exception = exception };
    			}
    		}
    
    		// ************************************************************************
    		public static ProcessWithOutputCaptureResult Execute(string executablePath, string arguments, int timeout = Timeout.Infinite, ProcessWindowStyle processWindowStyle = ProcessWindowStyle.Hidden)
    		{
    			var p = new ProcessExecutionWithOutputCapture();
    			return p.ExecuteInternal(executablePath, arguments, timeout, processWindowStyle);
    		}
    
    		// ************************************************************************
    		/// <summary>
    		/// Only support existing exectuable (no association or dos command which have no executable like 'dir').
    		/// But accept full path, partial path or no path where it will use regular system/user path.
    		/// </summary>
    		/// <param name="executablePath"></param>
    		/// <param name="arguments"></param>
    		/// <param name="timeout"></param>
    		/// <returns></returns>
    		private ProcessWithOutputCaptureResult ExecuteInternal(string executablePath, string arguments, int timeout = Timeout.Infinite, ProcessWindowStyle processWindowStyle = ProcessWindowStyle.Hidden)
    		{
    			ProcessWithOutputCaptureResult processWithOutputCaptureResult = null;
    
    			using (Process process = new Process())
    			{
    				process.StartInfo.FileName = executablePath;
    				process.StartInfo.Arguments = arguments;
    				process.StartInfo.UseShellExecute = false; // required to redirect output to appropriate (output or error) process stream
    
    				process.StartInfo.WindowStyle = processWindowStyle;
    				if (processWindowStyle == ProcessWindowStyle.Hidden)
    				{
    					process.StartInfo.CreateNoWindow = true;
    				}
    
    				process.StartInfo.RedirectStandardOutput = true;
    				process.StartInfo.RedirectStandardError = true;
    
    				try
    				{
    					process.Start();
    
    					bool hasSucceeded = process.WaitForExit(timeout);
    					processWithOutputCaptureResult = ProcessWithOutputCaptureResult.CreateOne(process.ExitCode, process.StandardOutput.ReadToEnd(), process.StandardError.ReadToEnd());
    					processWithOutputCaptureResult = ProcessWithOutputCaptureResult.CreateExpiredOne();
    
    					processWithOutputCaptureResult = new ProcessWithOutputCaptureResult();
    					processWithOutputCaptureResult.ExitCode = process.ExitCode;
    					processWithOutputCaptureResult.Output = process.StandardOutput.ReadToEnd();
    					processWithOutputCaptureResult.Error = process.StandardError.ReadToEnd();
    					processWithOutputCaptureResult.HasTimeout = !hasSucceeded;
    				}
    				catch (Exception ex)
    				{
    					if (ex.HResult == -2147467259)
    					{
    						ProcessWithOutputCaptureResult.CreateOneWithException(new FileNotFoundException("File not found: " + executablePath, ex));
    					}
    					else
    					{
    						ProcessWithOutputCaptureResult.CreateOneWithException(ex);
    					}
    				}
    			}
    
    			return processWithOutputCaptureResult;
    		}
    
    		// ************************************************************************
    
    	}
    }
