    double value = 2.95E-05;
    value = double.Parse(value.ToString(), System.Globalization.NumberStyles.Any);
    Console.WriteLine(string.Format("{0:F10}",value));
    Console.WriteLine($"{value:F10}");
    Console.WriteLine(value.ToString("F10}"));
    Console.WriteLine($"{value:0.##########}");
