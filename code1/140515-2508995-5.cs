    public static class JobDoerFactory
    {
        static Dictionary<Guid, JobDoer> cache;
        static JobDoerFactory()
        {
            // This is a bit naive implementation; we miss a lot of error
            // checking, but you'll get the idea :-)
            var jobDoers =
               (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(JobDoer))
                let attributes =
                    type.GetCustomAttribute(typeof(JobDoerAttribute), true)
                where attributes.Length > 0
                let attribute = attributes[0] as JobDoerAttribute
                select new { attribute.JobDoerId, type }).ToArray();
            var cache = new Dictionary<Guid, JobDoer>(jobDoers.Length);
            foreach (jobDoer in jobDoers)
            {
                cache[jobDoer.JobDoerId] =
                    (JobDoer)Activator.CreateInstance(jobDoer.type);
            }
             JobDoerFactory.cache = cache;
        }
        public static JobDoer CreateInstanceById(Guid jobDoerId)
        {
            return cache[jobDoerId];
        }
    }
