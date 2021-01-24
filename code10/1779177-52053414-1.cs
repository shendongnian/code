        public void TextLog()
        {
            try
            {
                Thread thr = Thread.CurrentThread;
                int j = 0;
                Log1.WriteLine("-----------------------------------------------------------------");
                Log1.WriteLine(_message + "    " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss:ffff"));
                if (_message == "Service Stopped ...............")
                {
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Thread thr2 = Thread.CurrentThread;
                        if (thr2.Name == "Thread1")
                        {
                            Log1.WriteLine(thr2.Name + " : " + i + "    " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss:ffff"));
                        }
                        else
                        {
                            Log1.WriteLine(thr2.Name + " ::: " + i + "    " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss:ffff"));
                        }
                        j = j + 1;
                        Log1.WriteLine("Thread will sleep now -----------------------------------------------------------------");
                        Thread.Sleep(1000);
                        Log1.WriteLine("Thread came out from sleeping -----------------------------------------------------------------");
                    }
                }
            }
            catch (Exception e)
            {
                _message = e.Message;
                Log1.WriteLine(e.ToString());
            }
        }
