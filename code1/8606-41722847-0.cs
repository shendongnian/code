    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ExecutionForwarder
    {
    	public class ProcessWithOutputCapture
    	{
    		// ************************************************************************
    		public class ProcessWithOutputCaptureResult
    		{
    			public string Output { get; private set; }
    			public string Error { get; private set; }
    			public bool HasTimeout { get; private set; }
    			public int ExitCode { get; private set; }
    
    			private static string _emptyString = "";
    
    			public static ProcessWithOutputCaptureResult CreateExpiredOne()
    			{
    				return new ProcessWithOutputCaptureResult() {HasTimeout = true, Output = _emptyString, Error = _emptyString};
    			}
    
    			public static ProcessWithOutputCaptureResult CreateOne(int exitCode, string output, string error)
    			{
    				return new ProcessWithOutputCaptureResult() { ExitCode = exitCode, Output = output, Error = error};
    			}
    		}
    
    		// ************************************************************************
    		private StringBuilder _sbOutput = new StringBuilder();
    		private StringBuilder _sbError = new StringBuilder();
    
    		private AutoResetEvent _outputWaitHandle = null;
    		private AutoResetEvent _errorWaitHandle = null;
    
    		public static ProcessWithOutputCaptureResult Execute(string executablePath, string arguments, int timeout = Timeout.Infinite, ProcessWindowStyle processWindowStyle = ProcessWindowStyle.Hidden)
    		{
    			var p = new ProcessWithOutputCapture();
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
    				process.StartInfo.UseShellExecute = false;
    
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
    
    					_sbOutput.AppendLine(process.StandardOutput.ReadToEnd());
    					_sbError.AppendLine(process.StandardError.ReadToEnd());
    
    					if (process.WaitForExit(timeout) && _outputWaitHandle.WaitOne(timeout) && _errorWaitHandle.WaitOne(timeout))
    					{
    						processWithOutputCaptureResult = ProcessWithOutputCaptureResult.CreateOne(process.ExitCode, _sbOutput.ToString(), _sbError.ToString());
    					}
    					else
    					{
    						processWithOutputCaptureResult = ProcessWithOutputCaptureResult.CreateExpiredOne();
    					}
    				}
    				finally
    				{
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
