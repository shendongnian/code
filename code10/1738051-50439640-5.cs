     public sealed class JobCreator
        {        
        
            public static void CreateJob<T>(JobInfo jInfo, ref IScheduler scheduler) where T : IJob
            {
                JobBuilder jbuilder = JobBuilder.Create<T>();
                jbuilder.WithIdentity(jInfo.JobName, jInfo.GroupName);
     
                if (jInfo.DataParamters != null && jInfo.DataParamters.Any())
                {
                    foreach (var item in jInfo.DataParamters)
                    {
                        jbuilder.UsingJobData(GetDataMap(item));
                    }
                }
     
                IJobDetail jobDetail = jbuilder.Build();
     
                TriggerBuilder tBuilder = TriggerBuilder.Create();
                tBuilder.WithIdentity(jInfo.TriggerName, jInfo.GroupName)
                        .StartNow()
                        .WithCronSchedule(jInfo.CronExpression);
                        //.WithSimpleSchedule(x => x
                        //    .WithIntervalInSeconds(10)
                        //    .RepeatForever());
     
                ITrigger trigger = tBuilder.Build();
     
                scheduler.ScheduleJob(jobDetail, trigger);
            }
        
            private static JobDataMap GetDataMap(DataParameter dataParameter)
            {
                JobDataMap jDataMap = new JobDataMap();
     
                switch (dataParameter.Value.GetType().Name)
                {
                    case "Int32":
                        jDataMap.Add(dataParameter.Key, (int)dataParameter.Value);
                        break;
                    case "String":
                        jDataMap.Add(dataParameter.Key, dataParameter.Value);
                        break;
                }
                return jDataMap;
            }
        }
