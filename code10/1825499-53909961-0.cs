    public delegate void LoggingDelegate(string str);
    public partial class Gui : Form
    {
        public void ShowLog(string status)
        {
            try
            {
                if (richtxtBxResult.InvokeRequired)
                {
                    this.Invoke(new Action<string>(ShowLog), status);
                }
                else
                {
                    richtxtBxResult.Text += Environment.NewLine + status;
                    richtxtBxResult.SelectionStart = richtxtBxResult.Text.Length;
                    richtxtBxResult.ScrollToCaret();
                    richtxtBxResult.Refresh();
                }
            }
            catch (Exception ex)
            {
                Program.WriteExceptionLog(ex);
            }
        }
        
        public void RunBackend()
        {
            var backend = new BackendClass();
            backend.LoggingEvent += ShowLog;
            Task.Run(() => backend.SomeAction());
        }
    }
    public class BackendClass
    {
        public event LoggingDelegate LoggingEvent;
        
        public void SomeAction()
        {
            // ...
            LoggingEvent?.Invoke("Log output");
            // ...
        }
    }
