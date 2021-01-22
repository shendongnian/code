    using System;
    using System.IO;
    class Program
    {
    static void Main()
    {
        string line = "";
        int value = 0;
        int max = 0;
        int min = 100;
        int total = 0;
        double count = 0.0;
        double average = 0;
        StreamReader fileReader = new StreamReader(@"data.txt");
        do
        {
            line = fileReader.ReadLine();
            if (line != null)
            {
                value = int.Parse(line);
                if (value > max)
                    max = value;
                if (value < min)
                    min = value;
                total += value;
                count++;
            } 
        } while (line != null);
        average = total / count;
        Console.WriteLine("Max: {0}", max);
        Console.WriteLine("Min: {0}", min);
        Console.WriteLine("Avg: {0:f2}", average); 
        Console.ReadLine();
    }//End Main()
    }//End class Program
