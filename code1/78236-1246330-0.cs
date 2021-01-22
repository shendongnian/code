    public static void VerifyTask(string server, string scheduledTaskToFind)
    {
         ScheduledTasks st = new ScheduledTasks(server);
    
         string[] taskNames = st.GetTaskNames();
         List<string> jobs = new List<string>(taskNames);
    
         Assert.IsTrue(jobs.Contains(scheduledTaskToFind), "unable to find " + scheduledTaskToFind);
    
         st.Dispose();
    }
