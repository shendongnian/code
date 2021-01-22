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
    			public string Output { get; private set; }
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
    				private set { _error = value; }
    			}
    			public bool HasTimeout { get; private set; }
    			public int ExitCode { get; private set; }
    			public Exception  Exception { get; private set; }
    
    			public bool HasSucceded => !HasTimeout && Exception == null;
    
    			public static ProcessWithOutputCaptureResult CreateExpiredOne()
    			{
    				return new ProcessWithOutputCaptureResult() {HasTimeout = true, Output = null, Error = null};
    			}
    
    			public static ProcessWithOutputCaptureResult CreateOne(int exitCode, string output, string error)
    			{
    				return new ProcessWithOutputCaptureResult() { ExitCode = exitCode, Output = output, Error = error};
    			}
    
    			public static ProcessWithOutputCaptureResult CreateOneWithException(Exception exception)
    			{
    				return new ProcessWithOutputCaptureResult() { Exception = exception};
    			}
    		}
    
    		// ************************************************************************
    		private StringBuilder _sbOutput = new StringBuilder();
    		private StringBuilder _sbError = new StringBuilder();
    
    		private AutoResetEvent _outputWaitHandle = null;
    		private AutoResetEvent _errorWaitHandle = null;
    
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
    
    				_outputWaitHandle = new AutoResetEvent(false);
    				_errorWaitHandle = new AutoResetEvent(false);
    				try
    				{
    					process.OutputDataReceived += ProcessOnOutputDataReceived;
    					process.ErrorDataReceived += ProcessOnErrorDataReceived;
    
    					process.Start();
    
    					process.BeginOutputReadLine();
    					process.BeginErrorReadLine();
    
    					// See: ProcessStartInfo.RedirectStandardOutput Property:
    					//		https://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k(System.Diagnostics.ProcessStartInfo.RedirectStandardOutput);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5.2);k(DevLang-csharp)&rd=true
    					// All 4 next lines should only be called when not using asynchronous read (process.BeginOutputReadLine() and process.BeginErrorReadLine())
    					//_sbOutput.AppendLine(process.StandardOutput.ReadToEnd());
    					//_sbError.AppendLine(process.StandardError.ReadToEnd());
    					//_sbOutput.AppendLine(process.StandardOutput.ReadToEnd());
    					//_sbError.AppendLine(process.StandardError.ReadToEnd());
    
    					if (process.WaitForExit(timeout) && _outputWaitHandle.WaitOne(timeout) && _errorWaitHandle.WaitOne(timeout))
    					{
    						processWithOutputCaptureResult = ProcessWithOutputCaptureResult.CreateOne(process.ExitCode, _sbOutput.ToString(), _sbError.ToString());
    					}
    					else
    					{
    						processWithOutputCaptureResult = ProcessWithOutputCaptureResult.CreateExpiredOne();
    					}
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
    				finally
    				{
    					process.CancelOutputRead();
    					process.CancelErrorRead();
    
    					process.OutputDataReceived -= ProcessOnOutputDataReceived;
    					process.ErrorDataReceived -= ProcessOnOutputDataReceived;
    
    					_outputWaitHandle.Close();
    					_outputWaitHandle.Dispose();
    
    					_errorWaitHandle.Close();
    					_errorWaitHandle.Dispose();
    				}
    			}
    
    			return processWithOutputCaptureResult;
    		}
    
    		// ************************************************************************
    		private void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs e)
    		{
    			if (e.Data == null)
    			{
    				_outputWaitHandle.Set();
    			}
    			else
    			{
    				_sbOutput.AppendLine(e.Data);
    			}
    		}
    
    		// ************************************************************************
    		private void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs e)
    		{
    			if (e.Data == null)
    			{
    				_errorWaitHandle.Set();
    			}
    			else
    			{
    				_sbError.AppendLine(e.Data);
    			}
    		}
    
    		// ************************************************************************
    	}
    }
