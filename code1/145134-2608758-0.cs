    using System.Diagnostics;
    PerformanceCounter oPerf1 = new PerformanceCounter();
    oPerf1.CategoryName = "Processor";
    oPerf1.CounterName = "% Processor Time";
    oPerf1.InstanceName = "0";
    int I;
    for (I = 0; (I <= 100); I++) {
        SomeListBox.Items.Add(oPerf1.NextValue);
        Threading.Thread.Sleep(20);
    }
