    private static Dictionary<Guid, JobDoer> BuildCache()
    {
        // This is a bit naive implementation; we miss some error checking,
        // but you'll get the idea :-)
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
            // Note that actually a single instance of the job doer is
            // cached by ID. This means that every Job Doer must be 
            // thread-safe and usable multiple times. If this is not 
            // feasable, you can also create store a set of Func<JobDoer> 
            // objects that enable creating a new instance on each call.
            cache[jobDoer.JobDoerId] =
                (JobDoer)Activator.CreateInstance(jobDoer.type);
        }
        return cache;
    }
