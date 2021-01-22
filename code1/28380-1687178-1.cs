    public class SendMail 
    {
        string[] NameArray = new string[10] { "Recipient 1", 
                                              "Recipient 2",
                                              "Recipient 3",
                                              "Recipient 4", 
                                              "Recipient 5", 
                                              "Recipient 6", 
                                              "Recipient 7", 
                                              "Recipient 8",
                                              "Recipient 9",
                                              "Recipient 10"
                                            };        
               
        public SendMail(int i, ManualResetEvent doneEvent)
        {
            Console.WriteLine("Started sending mail process for {0} - ", NameArray[i].ToString() + " at " + System.DateTime.Now.ToString());
            Console.WriteLine("");
            SmtpClient mailClient = new SmtpClient();
            mailClient.Host = Your host name;
            mailClient.UseDefaultCredentials = true;
            mailClient.Port = Your mail server port number; // try with default port no.25
            MailMessage mailMessage = new MailMessage(FromAddress,ToAddress);//replace the address value
            mailMessage.Subject = "Testing Bulk mail application";
            mailMessage.Body = NameArray[i].ToString();
            mailMessage.IsBodyHtml = true;
            mailClient.Send(mailMessage);
            Console.WriteLine("Mail Sent succesfully for {0} - ",NameArray[i].ToString() + " at " + System.DateTime.Now.ToString());
            Console.WriteLine("");
            
            _doneEvent = doneEvent;
        }
        public void ThreadPoolCallback(Object threadContext)
        {
            int threadIndex = (int)threadContext;
            Console.WriteLine("Thread process completed for {0} ...",threadIndex.ToString() + "at" +  System.DateTime.Now.ToString());
            _doneEvent.Set();
        }      
         
        private ManualResetEvent _doneEvent;
    }
    
    public class Program
    {
        static int TotalMailCount, Mailcount, AddCount, Counter, i, AssignI;  
        static void Main(string[] args)
        {
            TotalMailCount = 10;
            Mailcount = TotalMailCount / 2;
            AddCount = Mailcount;
            InitiateThreads();                     
            
            Thread.Sleep(100000);
        }
        
       static void InitiateThreads()
       {
            //One event is used for sending mails for each person email id as batch
           ManualResetEvent[] doneEvents = new ManualResetEvent[Mailcount];
            
            // Configure and launch threads using ThreadPool:
            Console.WriteLine("Launching thread Pool tasks...");
            for (i = AssignI; i < Mailcount; i++)            
            {
                doneEvents[i] = new ManualResetEvent(false);
                SendMail SRM_mail = new SendMail(i, doneEvents[i]);
                ThreadPool.QueueUserWorkItem(SRM_mail.ThreadPoolCallback, i);
            }
            Thread.Sleep(10000);
            // Wait for all threads in pool to calculation...
            //try
            //{
            // //   WaitHandle.WaitAll(doneEvents);
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.ToString());   
            //}
            Console.WriteLine("All mails are sent in this thread pool.");
            Counter = Counter+1;
            Console.WriteLine("Please wait while we check for the next thread pool queue");
            Thread.Sleep(5000);
            CheckBatchMailProcess();            
        }
        static  void CheckBatchMailProcess()
        {
            
            if (Counter < 2)
            {
                Mailcount = Mailcount + AddCount;
                AssignI = Mailcount - AddCount;
                Console.WriteLine("Starting the Next thread Pool");
                Thread.Sleep(5000);
                InitiateThreads();
            }
            else
            {
                Console.WriteLine("No thread pools to start - exiting the batch mail application");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
    }
   
