    class Program
    {
        public static async Task Main(string[] args)
        {
            var dataReader = new DataReader();
            dataReader.DataProgressChanged += (s, e) => Log.D($"*** Event - Processed {e.TaskId}");
            dataReader.DataReadCompleted += (s, e) => Log.D("*** Event - Data read complete");
            await dataReader.GetDataAsync();
            Console.ReadKey();
        }
    }
    public class DataReader
    {
        internal delegate void DataProgressChangedHandler(object sender, DataProgressChangedArgs e);
        internal delegate void DataReadCompleteHandler(object sender, DataReadCompleteArgs e);
        internal event DataProgressChangedHandler DataProgressChanged;
        internal event DataReadCompleteHandler DataReadCompleted;
        private SemaphoreSlim semaphore = new SemaphoreSlim(1);
        internal async Task GetDataAsync()
        {
            Log.D("Start");
            var tasks = CreateCursorReadTasks();
            var processingTasks = tasks.Select(AwaitAndProcessAsync).ToList();
            await Task.WhenAll(processingTasks);
            OnDataReadCompleted(new DataReadCompleteArgs());
        }
        private IList<ReadTaskWrapper> CreateCursorReadTasks()
        {
            var retval = new List<ReadTaskWrapper>();
            for (int totalrows = 0; totalrows < 4; totalrows++)
            {
                int taskId = totalrows;
                retval.Add(new ReadTaskWrapper
                {
                    Task = Task.Run(async () => { return await SimulateDbReadAsync(taskId); }),
                    Id = taskId
                });
            }
            return retval;
        }
        private async Task<string[][]> SimulateDbReadAsync(int taskId)
        {
            await semaphore.WaitAsync();
            Log.D($"Starting data read task {taskId}");
            await Task.Delay(5000);
            Log.D($"Finished data read task {taskId}");
            semaphore.Release();
            return new string[1][];
        }
        internal async Task AwaitAndProcessAsync(ReadTaskWrapper task)
        {
            string[][] rawdata = await task.Task;
            Log.D($"Start postprocessing of task {task.Id}");
            await Task.Delay(3000);
            Log.D($"Finished prostprocessing of task {task.Id}");
            OnDataProgressChanged(new DataProgressChangedArgs { TaskId = task.Id });
        }
        internal void OnDataProgressChanged(DataProgressChangedArgs args)
        {
            DataProgressChanged?.Invoke(this, args);
        }
        internal void OnDataReadCompleted(DataReadCompleteArgs args)
        {
            DataReadCompleted?.Invoke(this, args);
        }
        internal class DataProgressChangedArgs : EventArgs
        {
            public int TaskId { get; set; }
        }
        internal class DataReadCompleteArgs : EventArgs
        {
        }
    }
    public class ReadTaskWrapper
    {
        public int Id { get; set; }
        public Task<string[][]> Task { get; set; }
    }
    public static class Log
    {
        public static void D(string msg)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {msg}");
        }
    }
