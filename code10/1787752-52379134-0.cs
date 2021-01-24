        public class JobSchedulerController : Controller
        {
            // GET: JobScheduler
    
    
            #region Start
            public static async void Start(List<string> Email)
            {
                DateTime today = DateTime.Now;
                int days5 = 120;
                int days10 = 240;
    
                int days7 = 168;
    
                int minute_10 = 10;
                int minute_20 = 20;
                string EmailAdress;
    
                int cont = 0;
                foreach (var item in Email)
                {
                    ++cont;
    
                    EmailAdress = item.ToString();
    
                    IJobDetail job = JobBuilder.Create<EmailJob>()
                    .UsingJobData("Email_List", EmailAdress)
                    .Build();
    
                    IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                    await scheduler.Start();
    
                    ITrigger trigger2 = TriggerBuilder.Create() //Fecha, día exacto, 5 días después, 10 días después.
                    .WithIdentity("trigger_"+cont, "group_" + cont)
                    .StartAt(today)
                    //.WithCronSchedule("")
                    .WithSimpleSchedule(x => x
                        .WithIntervalInMinutes(1)
                        //.WithIntervalInHours(days5) //Equivale a 5 días.
                        .WithRepeatCount(2))
                    .Build();
    
                    await scheduler.ScheduleJob(job, trigger2);
                }
            }
            #endregion
        }
    }
