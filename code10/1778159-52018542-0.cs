            var task = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent task");
                var subTask = Task.Factory.StartNew(
                    () =>
                    {
                        Console.WriteLine("Child");
                        throw new Exception("Exception in the child");
                    }, TaskCreationOptions.AttachedToParent);
                throw new Exception("Exception in the parent");
            });
            try
            {
                task.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e);
            }
