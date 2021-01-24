            public async Task DoWebserviceStuffAsync(TaskCompletionSource<bool> taskCompletionSource)
            {
                for (int i = 0; i < 10; i++)
                {
                    //your webservice call
                    await Task.Delay(5000);
    
                    //some condition
                    if (i == 1)
                    {
                        //after setting this your CallingMethod finishes 
                        //waiting the await taskCompletionSource.Task;
                        taskCompletionSource.TrySetResult(true);
                    }
                }
            }
    
            private async Task CallerMethod()
            {
                var taskCompletionSource = new TaskCompletionSource<bool>();
                //call method without await
                //care: You cannot catch exceptions without await
                DoWebserviceStuffAsync(taskCompletionSource);
                //wait for the DoWebserviceStuffAsync to set a result on the passed TaskCompletionSource
                await taskCompletionSource.Task;
            }
