    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    static void Main(string[] args)
    {
        string text_double = "0.7598";
        string message = "Using double.Parse():   ";
        try
        {
            double confidence = double.Parse(text_double, CultureInfo.InvariantCulture);
            message += text_double + " Converted To " + confidence;
        }
        catch (Exception ex)
        {
            message += ex.Message;
        }
        Console.WriteLine(message);
        message = "Using Convert.ToDouble:   ";
        try
        {
            double confidence = Convert.ToDouble(text_double, CultureInfo.InvariantCulture);
            message += text_double + " Converted To " + confidence;
        }
        catch (Exception ex)
        {
            message += ex.Message;
        }
        Console.WriteLine(message);
        Console.ReadKey();
        return;
    }
