    static class Program
    {
        [STAThread]
        static void Main()
        {
			if (SingleApplicationDetector.IsRunning()) {
				return;
			}
			Application.Run(new MainForm());
			SingleApplicationDetector.Close();
        }
    }
