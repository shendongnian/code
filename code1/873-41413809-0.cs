        private class InitializerTest
        {
            static private int _x;
            static public string Status()
            {
                return "_x = " + _x;
            }
            static InitializerTest()
            {
                System.Diagnostics.Debug.WriteLine("InitializerTest() starting.");
                _x = 1;
                Thread.Sleep(3000);
                _x = 2;
                System.Diagnostics.Debug.WriteLine("InitializerTest() finished.");
            }
        }
        private void ClassInitializerInThread()
        {
            System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.GetHashCode() + ": ClassInitializerInThread() starting.");
            string status = InitializerTest.Status();
            System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.GetHashCode() + ": ClassInitializerInThread() status = " + status);
        }
        private void classInitializerButton_Click(object sender, EventArgs e)
        {
            new Thread(ClassInitializerInThread).Start();
            new Thread(ClassInitializerInThread).Start();
            new Thread(ClassInitializerInThread).Start();
        }
