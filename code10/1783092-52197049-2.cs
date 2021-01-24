    public class PersonSerialPort : IDisposable
    {
        private readonly SerialPort port;
        
        /// <summary>
        /// Timeout in milliseconds
        /// </summary>
        private const int Timeout = 5000;
        public PersonSerialPort()
        {
            // port initializing here
            port = new SerialPort(/*your parameters here*/);
            port.Open();
        }
        public async Task<Person> GetPerson()
        {
            // set up the task completion source
            var tcs = new TaskCompletionSource<Person>();
            // handler of DataReceived event of port
            var handler = default(SerialDataReceivedEventHandler);
            handler = (sender, eventArgs) =>
            {
                try
                {
                    Person result = new Person();
                    // some logic for filling Person fields
                    // or set it null or whatever you need
                    // you are free to not set result and wait for next event fired too
                    tcs.SetResult(result);
                }
                finally
                {
                    port.DataReceived -= handler;
                }
            };
            port.DataReceived += handler;
            // send request for person
            port.Write("Give a person number 1");
            if (await Task.WhenAny(tcs.Task, Task.Delay(Timeout)) == tcs.Task)
            {
                return tcs.Task.Result;
            }
            else
            {
                port.DataReceived -= handler;
                throw new TimeoutException("Timeout has expired");
            }
        }
        public void Dispose()
        {
            port?.Dispose();
        }
    }
