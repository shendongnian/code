    var maxCount = counts.Max(); // needs "using System.Linq;" at the top
    for (int i = 2; i <= 12; i++)
    {
        var width = ((Console.WindowWidth - 10) * counts[i]) / maxCount; // make it proportional
        Console.WriteLine($"{i}\t{new string('*', width)}");
    }
