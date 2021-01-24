    string input = "5 lb in kg";
    string[] parts = input.Split(new[] { " in "}, StringSplitOptions.RemoveEmptyEntries);
    string massText = parts[0];
    string toUnitText = parts[1];
    
    MassUnit toUnit = UnitSystem.Default.Parse<MassUnit>(toUnitText);
    Mass mass = Mass.Parse(massText);
    double toValue = mass.As(toUnit);
    Console.WriteLine(toValue); // 2.26796185
