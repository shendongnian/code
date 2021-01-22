    using System;
    using System.Windows.Forms;
    public interface ISplashForm
    {
        IAsyncResult BeginInvoke(Delegate method);
        DialogResult ShowDialog();
        void Close();
        void SetStatusText(string text);
    }
    
    using System.Windows.Forms;
    public partial class SplashForm : Form, ISplashForm
    {
        public SplashForm()
        {
            InitializeComponent();
        }
        public void SetStatusText(string text)
        {
            _statusText.Text = text;
        }
    }
    
    using System;
    using System.Windows.Forms;
    using System.Threading;
    public static class SplashUtility<T> where T : ISplashForm
    {
        private static T _splash = default(T);
        public static void Show()
        {
            ThreadPool.QueueUserWorkItem((WaitCallback)delegate
            {
                _splash = Activator.CreateInstance<T>();
                _splash.ShowDialog();
            });
        }
    
        public static void Close()
        {
            if (_splash != null)
            {
                _splash.BeginInvoke((MethodInvoker)delegate { _splash.Close(); });
            }
        }
    
        public static void SetStatusText(string text)
        {
            if (_splash != null)
            {
                _splash.BeginInvoke((MethodInvoker)delegate { _splash.SetStatusText(text); });
            }
        }
    }
