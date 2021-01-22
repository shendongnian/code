    /// <summary>
    /// An MSBuild task that checks to see if MQ is installed on the current machine.
    /// </summary>
    public class IsMQInstalled : Task
    {
        /* Constructors removed for brevity */
        /// <summary>Is MQ installed?</summary>
        [Output]
        public bool Installed { get; set; }
        /// <summary>The method called by MSBuild to run this task.</summary>
        /// <returns>true, task will never report failure</returns>
        public override bool Execute()
        {
            try
            {
                // this will fail with an exception if MQ isn't installed
                new MQQueueManager();
                Installed = true;
            }
            catch { /* MQ is not installed */ }
            return true;
        }
    }
