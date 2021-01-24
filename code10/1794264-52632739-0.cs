    Dictionary<string, int> machines = new Dictionary<string, int>();
    // your reading loop here..
       string machine = ..// your retrieval code here
       if (!machines.ContainsKey(machine) ) machines.Add(machine, machines.Count);
       // now add the point:
       int px = yourSeries.Points.AddXY(machines[machine], yourYvalue1, yourYvalue2);
       yourSeries.Points[px].AxisLabel = machine;
       ..
    // loopend
