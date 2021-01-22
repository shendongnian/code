try    
{        
  System.Diagnostics.Process p = new System.Diagnostics.Process();        
  p.StartInfo.UseShellExecute = false;        
  p.StartInfo.FileName = Server.MapPath(@"\iPhoneXMLCreator.exe");        
  p.StartInfo.WorkingDirectory = Server.MapPath(@"\");        
  
  // redirect stdout
  p.StartInfo.RedirectStandardOutput = true;       
  var ConsoleOutput = new StringBuilder();
  p.OutputDataReceived += (s, e) => ConsoleOutput.AppendLine(e.Data);  
  
  p.Start();        
  p.BeginOutputReadLine(); // if I remember correctly, you have to call Start() first or you get an exception
  p.WaitForExit();        
  string output = ConsoleOutput.ToString();
  lblResult.Text = "Success!";    
}    
catch (Exception ex)    
{        
  lblResult.Text = "Oops, there was a problem.<br><Br>" + ex.Message;    
}
