    StreamReader convert = new StreamReader("../file.txt");
    string line = convert.ReadLine();
    String inputMeasurement = Console.ReadLine();
    string[] inputMeasurementArray = inputMeasurement.Split(',');
    while (line != null)
    {
        string[] fileMeasurementArray = line.Split(',');
        if (fileMeasurementArray[0] == inputMeasurementArray[1])
        {
            if (fileMeasurementArray[1] == inputMeasurementArray[2])
            {
                Console.WriteLine("{0}", fileMeasurementArray[2]);
            }
            else
            {
                Console.WriteLine("False");
            }
        }
        else
        {
            Console.WriteLine("False");
        }
        line = convert.ReadLine();
    }
    Console.ReadKey();
