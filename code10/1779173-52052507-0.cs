    Regex regex = new Regex("flashplayer_([0-9]+)_sa");
    // Get all processes and use Linq to filter on the regex pattern
    var processes = Process.GetProcesses().Where(p => regex.IsMatch(p.ProcessName));
    
    foreach (var proc in processes)
    {
        // do something
    }
