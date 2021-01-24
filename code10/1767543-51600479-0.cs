        private async Task DoSomethingAsync()
        {
            try
            {
                IEnumerable<string> enumerable = new List<string> { "st", "st" };
                // start all tasks and store them in an array
                var tasks = enumerable.Select(TaskAsync).ToArray();
                // do something more without waiting until all tasks above completed
                // ...
                // await all tasks
                var completionTask = Task.WhenAll(tasks);
                await completionTask;
                // handle task exception if any exists
                if (completionTask.Status == TaskStatus.Faulted)
                {
                    foreach (var task in tasks)
                    {
                        if (task.Exception != null)
                        {
                            // throw an exception or handle the exception, e.g. log the exceptions to file / database
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // handle your exception, e.g. write a log to file / database
            }
        }
        private Task TaskAsync(string item)
        {
            // Task.Delay() is just a placeholder
            // do some async stuff here, e.g. access web services or a database
            return Task.Delay(10000);
        }
