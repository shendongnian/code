using System;
using System.Management;
class Program
{
    public static void Main()
    {
        WqlEventQuery q = new WqlEventQuery();
        q.EventClassName = "__InstanceModificationEvent ";
        q.Condition = @"TargetInstance ISA 'Win32_LocalTime' AND TargetInstance.Hour = 22 AND TargetInstance.Minute = 7 AND TargetInstance.Second = 59";
        Console.WriteLine(q.QueryString);
        using (ManagementEventWatcher w = new ManagementEventWatcher(q))
        {
            w.EventArrived += new EventArrivedEventHandler(TimeEventArrived);
            w.Start();
            Console.ReadLine(); // Block this thread for test purposes only....
            w.Stop();
        }
    }
    static void TimeEventArrived(object sender, EventArrivedEventArgs e)
    {
        Console.WriteLine("This is your wake-up call");
        Console.WriteLine("{0}", new
        DateTime((long)(ulong)e.NewEvent.Properties["TIME_CREATED"].Value));
    }
}
