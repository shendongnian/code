    //Create list of thread
        private List<Thread> threads = new List<Thread>();
        private void RunThread(YourClass yourclass)
        {
            switch (yourclass.ConnStat)
            {
                case ConnStatus.DISCONNECTED:
                    {
                        Thread oldthread = threads.FirstOrDefault(i => i.Name == yourclass.ID.ToString());
                        if (oldthread != null)
                        {
                            //Clean old thread
                            threads.Remove(oldthread);
                        }
                        else
                        {
                            //Add event here
                            yourclass.OnResponseEvent += new EventHandler<YourClass.ResponseEventArgs>(work_OnResponseEvent);
                            yourclass.OnNotificationEvent += new EventHandler<YourClass.NotificationEventArgs>(work_OnInfoEvent);
                        }
                        try
                        {
                            //Add thread to list
                            Thread thread = new Thread(new ThreadStart(() => yourclass.Initialize())) { Name = yourclass.ID.ToString(), IsBackground = true };
                            thread.Start();
                            threads.Add(thread);
                            Thread.Sleep(100);
                        }
                        catch (ThreadStateException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
                case ConnStatus.CONNECTED:
                    {
                        MessageBox.Show(string.Format("ID:{0}, is currently running!", yourclass.ID));
                        break;
                    }
                case ConnStatus.AWAITING:
                    {
                        MessageBox.Show(string.Format("ID:{0}, is currently awaiting for connection!", yourclass.ID));
                        break;
                    }
            }
        }
        //To control your class within thread
        private void StopThread(YourClass yourclass)
        {
            if (yourclass.ConnStat == ConnStatus.CONNECTED || yourclass.ConnStat == ConnStatus.AWAITING)
            {
                //Call your method
                yourclass.Disconnect();
                yourclass.OnResponseEvent -= work_OnResponseEvent;
                yourclass.OnDBResponseEvent -= work_OnDBResponseEvent;
                yourclass.OnNotificationEvent -= work_OnInfoEvent;
                Thread oldthread = threads.FirstOrDefault(i => i.Name == yourclass.ID.ToString());
                if (oldthread != null) threads.Remove(oldthread);
            }
        }
