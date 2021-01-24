    public static string GetProcessInstanceName(int PID)
    {
        PerformanceCounterCategory cat = new 
    PerformanceCounterCategory("Process");
    var[] instances = cat.GetInstanceNames();
    foreach (var instance in instances)
    {
        using (PerformanceCounter cnt = new 
    PerformanceCounter("Process", "ID Process", instance, 
    true))
        {
            int val = System.Convert.ToInt32(cnt.RawValue);
            if (val == PID)
                return instance;
            }
        }
    }
