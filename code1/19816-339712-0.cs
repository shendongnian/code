    using System.Runtime.InteropServices;
    
    [ComVisible(true)]
    public class External
    {
        private static MainWindow m_mainWindow = null;
        public External(MainWindow mainWindow)
        {
            m_mainWindow = mainWindow; 
        }
        public void CloseApplication()
        {
            m_mainWindow.Close();
        }
        public string CurrentDate(string format)
        {
            return DateTime.Now.ToString(format);  
        }
    }
