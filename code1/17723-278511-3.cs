        public bool TryDoTasks(MyTask[] taskList, out List<Exception> exceptions)
        {
            exceptions = new List<Exception>();
            foreach (MyTask task in taskList)
            {
                try
                {
                    DoTask(task);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Count > 0)
            {
                return false;
            }
            else
            {
                exceptions = null;
                return true;
            }
        }
