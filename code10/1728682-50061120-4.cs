    public class TaskExamples
    {       
        public async void DoAsyncVoid()
        {
            await Task.Delay(200);
        }
        public async Task DoAsyncTask()
        {
            await Task.Delay(200);
        }
        public async Task<int> DoReturnValueTask()
        {
            await Task.Delay(200);
            return 50;
        }
        public async void CallingTasks()
        {
            DoAsyncVoid(); //This can't use await because it is 'void' so the next line is ran as soon as this command reaches the first 'true awaitable' await.
            await DoAsyncTask(); //This runs before DoAsyncVoid is complete.
            var value = await DoReturnValueTask(); //This waits until 'DoAsyncTask' is complete because it is a Task and awaited.
            await new MessageDialog(value.ToString()).ShowAsync(); //This waits until 'DoReturnValueTask' is complete and value will be 50 in this case.
            //All code here waits until the Dialog is closed because it is also awaited.
        }
    }
