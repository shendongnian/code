    var conversions = new Dictionary<string,Dictionary<string,double>>();
    var convert = new StreamReader("../../convert.txt");
    while ((var line = convert.ReadLine()) != null)
    {
        string components = line.Split(',');
        Dictionary<string,double> unitConversions;
        if (conversions.ContainsKey( components[0] ))
        {
            unitConversions = conversions[components[0]];
        }
        else
        {
            unitConversions = new Dictionary<string,double>();
            conversions.Add( components[0], unitConversions );
        }
        unitConversions.Add( components[1], Convert.ToDouble( components[2] ) );
    }
    while (true)
    {
        //ask for the conversion information     
        Console.WriteLine("Enter the conversion in the form (Amount, Convert from, Convert to)");     
        var inputMeasurement = Console.ReadLine();     
        var inputMeasurementArray = inputMeasurement.Split(',');
        bool converted = false;
        Dictionary<string,double> unitConversion;
        if (conversions.TryGetValue(  inputMeasurementArray[1], out unitConversion ))
        {
             double conversionFactor;
             if (unitConversion.TryGetValue( inputMeasurementArray[2], out conversionFactor ))
             {
                 converted = true;
                 conversion = Convert.ToDouble( inputMeasurementArray[0] ) * conversionFactor;
                 Console.WriteLine("{0} {1} is {2} {3} \n", inputMeasurementArray[0], inputMeasurementArray[1], conversion, inputMeasurementArray[2]);              
             }
        }
        if (!converted)
        {
             Console.WriteLine("Please enter two valid conversion types\n");
        }
    }
                            
