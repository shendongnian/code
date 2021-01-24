    using System.Diagnostics;
    public class KillProcess
    {
        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);
        Process _KillProcess(int Hwnd)
        {
            int id;
            GetWindowThreadProcessId(Hwnd, out id);
            Process _Process = Process.GetProcessById(id);
			
			_Process.Kill();
        }
    }
