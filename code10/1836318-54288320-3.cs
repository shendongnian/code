      static void Main(string[] args)
        {
            var receivers = new List<string>();
            receivers.Add("Email1");
            receivers.Add("Email2");
            receivers.Add("Email3");
            receivers.Add("Email4");
            receivers.Add("Email5");
            receivers.Add("Email6");
            receivers.Add("Email7");
            receivers.Add("Email8");
            receivers.Add("Email9");
            receivers.Add("Email10");
            receivers.Add("Email11");
            receivers.Add("Email12");
            var peopleToWait = 5;
            var secondsToWait = 20;
            
            var counter = 0;
            foreach (var receiver in receivers)
            {
                ParameterizedThreadStart pts = new ParameterizedThreadStart(SendMail);
                Thread th = new Thread(pts);
                th.Start(receiver);
                counter++;
                if (counter % peopleToWait == 0)
                    Thread.Sleep(secondsToWait * 1000);
            }
            Console.ReadLine();
        }
        static void SendMail(object Email)
        {
            Console.WriteLine("Sending Mail to " + Email);
        }
