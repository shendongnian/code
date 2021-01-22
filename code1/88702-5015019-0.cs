            using (TaskService ts = new TaskService())
            {
                // Create a new task
                const string taskName = "RunMyProcessNowAsUser";
                Task t = ts.AddTask(taskName,
                   new TimeTrigger() { StartBoundary = DateTime.Now, Enabled = false },
                   new ExecAction("YourProcess.exe");
                t.Run();
                // delete the task after 2 seconds.
                new Action(() =>
                {
                    Thread.Sleep(2000);
                    using (TaskService ts2 = new TaskService())
                    {
                        ts2.RootFolder.DeleteTask(taskName);
                    }
                }).BeginInvoke(null, null);
            }
