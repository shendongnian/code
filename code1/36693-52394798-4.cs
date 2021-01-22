using Microsoft.VisualBasic.Devices;
    string SimpleOSName()
    {
        var parts = new ComputerInfo().OSFullName.Split(' ').ToArray();
        return String.Join(" ", parts.Skip(parts.IndexOf("Windows")).Take(2));
    }
