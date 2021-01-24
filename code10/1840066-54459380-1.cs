    public class UpdateRandomNumber
    {
        private bool _continue = true;
        private TestHub testHub;
        public UpdateRandomNumber(TestHub testHub)
        {
            this.testHub=testHub;
        }
        public UpdateRandomNumber()
        {
            var task = new Task(() => RandomNumberLoop(),
                                TaskCreationOptions.LongRunning);
            task.Start();
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
                 await this.testHub.SendRandomNumber(number);
            }
        }
        public void Stop()
        {
            _continue = false;
        }
    }
