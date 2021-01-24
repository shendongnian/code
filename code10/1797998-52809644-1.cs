    class Program {
        static void Main(string[] args) {
            NinjectModule ninjectModule = new NinjectModule();
            var kernel = ninjectModule.Init();
            //Uncomment for test
            //WithoutQuartz(kernel);
            WithQuartz(kernel).GetAwaiter().GetResult();
            Console.ReadKey();
        }
        /// <summary>
        /// Not Working example - Ninject + log4net + Quartz.
        /// </summary>
        /// <param name="kernel"></param>
        public static async Task WithQuartz(IKernel kernel) {
            ILog log = kernel.Get<ILog>(); //resolve logger before scheduler seems to make things work
            var factory = kernel.Get<Task<IScheduler>>();
            var scheduler = await factory;
            IJobDetail job = JobBuilder.Create<SimpleJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()              // создаем триггер
                .WithIdentity("trigger1", "group1")                 // идентифицируем триггер с именем и группой
                .StartNow()                                         // запуск сразу после начала выполнения
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(3) // настраиваем выполнение действия 
                    .RepeatForever())                   // бесконечное повторение
                .Build();                               // создаем триггер
            await scheduler.ScheduleJob(job, trigger);  // начинаем выполнение работы
            await scheduler.Start();
        }
    } 
