    using SHDocVw;
            InternetExplorer ie = new InternetExplorer();            
            ie.Visible = false;
            ie.Navigate("http://xxx");
            Thread.Sleep(1000);
            while (ie.Busy)
            {
                Thread.Sleep(1000);
            }
,,,
...
