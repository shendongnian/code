    public static class Util
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static MenuBar menuBar = null;
        public static void MenuItem(object obj)
        {
            string[] path = obj as string[];
            menuBar.MenuItem(path).Click();
        }
        public static void ClickMenu(MenuBar mainMenu, params string[] menuItems)
        {
            menuBar = mainMenu;
            System.Threading.Thread t = new System.Threading.Thread(MenuItem);
            t.Priority = System.Threading.ThreadPriority.Highest;
            t.Start(menuItems);
            DateTime startTime = DateTime.Now;
            while (t.IsAlive)
            {
                System.Threading.Thread.Sleep(100);
            }
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;
            if (duration.Seconds > 60)
            {
                log.Info($"Menu Operation duration = {duration.Seconds} sec");
            }
        }
    }
