    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class Form1 : Form
    {
    [DllImport("coredll")]
    static extern IntPtr GetForegroundWindow();
    [DllImport("coredll")]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
    protected override void OnDeactivate(EventArgs e)
    {
        base.OnDeactivate(e);
        //if the foreground window was not created by this application, exit this application
        IntPtr foregroundWindow = GetForegroundWindow();
        int foregroundProcId;
        GetWindowThreadProcessId(foregroundWindow, out foregroundProcId);
        using (Process currentProc = Process.GetCurrentProcess())
        {
            if (foregroundProcId != currentProc.Id)
            {
                Debug.WriteLine("Exiting application.");
                Application.Exit();
            }
        }
    }
