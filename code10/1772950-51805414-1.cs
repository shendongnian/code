    public MissileCoordinates ReadCoordinates()
    {
        PrintLine($"Enter Coordinates", ConsoleColor.White);
        var move = Console.ReadLine();
        List<string> errors = constraintValidator.ValidateMissile(move).ToList();
    
        if (errors.Any())
        {
            foreach (var error in errors)
            {
                PrintLine(error, ConsoleColor.White);
            }
            return ReadCoordinates();
        }
        else
        {
            var positionXY = move.ToCharArray();
    
            return new MissileCoordinates
            {
                PosX = Int32.Parse(positionXY[0].ToString()),
                PosY = Int32.Parse(positionXY[1].ToString())
            };
        }
    }
