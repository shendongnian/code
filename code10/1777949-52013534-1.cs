    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Quartz;
    using Quartz.Impl;
    using System.Net;
    using System.Net.Mail;
    using Quartz.Logging;
    using System.Threading.Tasks;
    
    namespace WEB_Project.Models
    {
        public class JobScheduler
        {
            public static async void Start()
            {
                IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                await scheduler.Start();
    
                IJobDetail job = JobBuilder.Create<EmailJob>().Build();
    
                ITrigger trigger = TriggerBuilder.Create()
                    .WithDailyTimeIntervalSchedule
                      (s =>
                         s.WithIntervalInHours(24)
                        .OnEveryDay()
                        .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(0, 0))
                      )
                    .Build();
    
                ITrigger trigger1 = TriggerBuilder.Create()
                    .WithIdentity("trigger_1", "group_1")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(20)
                        .RepeatForever())
                    .Build();
    
                await scheduler.ScheduleJob(job, trigger1);
            }
        }
    }
