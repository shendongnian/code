               var startInfo = new System.Diagnostics.ProcessStartInfo
    			{
    				FileName = exePath,
    				Arguments = " ", //this could be tricky
    				UseShellExecute = false,
    				RedirectStandardError = true,
    				RedirectStandardOutput = true,
    				CreateNoWindow = true
    			};
    
    			try
    			{
    				using (var process = new System.Diagnostics.Process())
    				{
    					process.StartInfo = startInfo;
    
    					process.OutputDataReceived += (sender, args) => Logger.Warn("OutputStream: " + args.Data);
    					process.ErrorDataReceived += (sender, args) => Logger.Warn("ErrorStream: " + args.Data);
    
    					if (!process.Start())
    					{
                            // not started
                        }
    
    					process.BeginErrorReadLine();
    					process.BeginOutputReadLine();
    
    					if (!process.WaitForExit(60_000))
    					{
                            \\Process ended with timeout. 60_000";
                        }
    				}
    			}
    			catch (Exception e)
    			{
    				\\ O_o
    				throw;
    			}
