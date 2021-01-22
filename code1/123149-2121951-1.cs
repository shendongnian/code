System.Diagnostics.ProcessStartInfo procInfo = new System.Diagnostics.ProcessStartInfo();
procInfo.CreateNoWindow = true;
procInfo.UseShellExecute = true;
procInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
System.Diagnostics.Process proc = new System.Diagnostics.Process();
proc.StartInfo = procInfo;
proc.EnableRaisingEvents = true;
proc.Exited += new EventHandler(proc_Exited);
proc.OutputDataReceived += new DataReceivedEventHandler(proc_OutputDataReceived);
proc.Start(...)
// Do something with proc.Handle...
void  proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
{
   /* Do something here... */
}
void  proc_Exited(object sender, EventArgs e)
{
/* Do something here... */
}
