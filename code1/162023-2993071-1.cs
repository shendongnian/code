    public static void Main()
    {
        using (customSchedulerClass myScheduler = new customSchedulerClass())
        {
            c.scheduleSomeStuff();
        }
        console.WriteLine("Now that you're out of the using statement the resources have been disposed");
    }
