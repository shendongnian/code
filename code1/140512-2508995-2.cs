    public static class JobDoerFactory
    {
        public static JobDoer CreateInstanceById(Guid jobDoerId)
        {
            // Naive and slow implementation, but error checks can be added
            // and results could be cached of course and performance can be
            // as good as manually filling in a dictionary. :-)
            var jobDoerType =
            (from assembly in AppDomain.CurrentDomain.GetAssemblies()
             from type in assembly.GetTypes()
             where type.IsSubclassOf(typeof(JobDoer))
             let attributes =
                 type.GetCustomAttribute(typeof(JobDoerAttribute), true)
             where attributes.Length > 0
             let attribute = attributes[0] as JobDoerAttribute
             where attribute.JobDoerId == jobDoerId
             select type).Single();
            return (JobDoer)Activator.CreateInstance(jobDoerType);
        }
    }
