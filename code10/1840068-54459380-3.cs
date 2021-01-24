    public class UpdateRandomNumber
    {
        private bool _continue = true;
        private IHubContext<TestHub> testHub;
        public UpdateRandomNumber(IHubContext<TestHub> testHub)
        {
            this.testHub=testHub;
        }
        private async void RandomNumberLoop()
        {
            Random r = new Random();
            while (_continue)
            {
                Thread.Sleep(3000);
                int number = r.Next(0, 100);
                Console.WriteLine("The random number is now " + number);
                // Send new random number to connected subscribers here
                 await testHub.Clients.All.SendAsync($"ReceiveRandomNumber", number);
            }
        }
        public void Stop()
        {
            _continue = false;
        }
    }
