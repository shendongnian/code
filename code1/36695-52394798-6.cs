using Microsoft.VisualBasic.Devices;
    string SimpleOSName()
    {
        var name = new ComputerInfo().OSFullName;
        var parts = name.Split(' ').ToArray();
        var take = name.Contains("Server")?3:2;
        return string.Join(" ", parts.Skip(parts.IndexOf("Windows")).Take(take));
    }
