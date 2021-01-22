    var semaphores = new List<AutoResetEvent>();
            foreach (String fileName in filesToConvert)
            {
                String file = fileName;
                AutoResetEvent[] array;
                lock (semaphores)
                {
                    array = semaphores.ToArray();
                }
                if (array.Count() >= 10)
                {
                    WaitHandle.WaitAny(array);
                }
                var semaphore = new AutoResetEvent(false);
                lock (semaphores)
                {
                    semaphores.Add(semaphore);
                }
                ThreadPool.QueueUserWorkItem(
                  delegate
                  {
                      Convert(file);
                      lock (semaphores)
                      {
                          semaphores.Remove(semaphore);
                      }
                      semaphore.Set();
                  }, null);
            }
