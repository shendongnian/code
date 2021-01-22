    Process p = Process.GetProcessById(proc_id);
    TimeSpan begin_cpu_time = p.TotalProcessorTime;
    //... wait a while
    p.Refresh();
    TimeSpan end_cpu_time = p.TotalProcessorTime;
    if(end_cpu_time - begin_cpu_time < TimeSpan.FromMillis(thresholdMillis))
    {
        //..process is idle
    }
    else
    {
        //..process is not idle
    }
