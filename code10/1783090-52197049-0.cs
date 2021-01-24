    public class PersonSerialPort : IDisposable
    {
        private readonly SerialPort port;
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
                
            return await tcs.Task;
        }
        public void Dispose()
        {
            port?.Dispose();
        }
    }
