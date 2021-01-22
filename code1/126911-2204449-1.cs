System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo("arp", "-a");
ps.CreateNoWindow = false;
ps.RedirectStandardOutput = true;
using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
{
    proc.StartInfo = ps;
    proc.Start();
    System.IO.StreamReader sr = proc.StandardOutput;
    while (!proc.HasExited) ;
    string sResults = sr.ReadToEnd();
}
