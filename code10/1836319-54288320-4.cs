      static void Main(string[] args)
        {
            var receivers = new List<List<string>>();
            var group1 = new List<string>();
            group1.Add("Email1");
            group1.Add("Email2");
            group1.Add("Email3");
            receivers.Add(group1);
            var group2 = new List<string>();
            group2.Add("Email4");
            group2.Add("Email5");
            group2.Add("Email6");
            receivers.Add(group2);
            var group3 = new List<string>();
            group3.Add("Email7");
            group3.Add("Email8");
            group3.Add("Email9");
            receivers.Add(group3);
            var group4 = new List<string>();
            group4.Add("Email10");
            group4.Add("Email11");
            group4.Add("Email12");
            receivers.Add(group4);
            var secondsToWait = 3;
            
            foreach (var receiver in receivers)
            {
                ParameterizedThreadStart pts = new ParameterizedThreadStart(SendMail);
                Thread th = new Thread(pts);
                th.Start(receiver);
                Thread.Sleep(secondsToWait * 1000);
            }
            Console.ReadLine();
        }
        static void SendMail(object Email)
        {
            var group = (List<string>)Email;
            //MailMessage abcd = new MailMessage();
            //abcd.To.Add(String.Join(",", group));
            Console.WriteLine("Sending Mail to " + String.Join(",", group));
        }
