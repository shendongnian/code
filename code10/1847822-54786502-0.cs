    private static string GetFittedStringToPrint(XGraphics gfx, XFont font, XRect rect, 
    string input)
    {
        var output = input;
        var stringMeasurement = gfx.MeasureString(input, font);
        if (stringMeasurement.Width > rect.Width)
        {
            var inputMinusOneChar = input;
            do
            {
                inputMinusOneChar = inputMinusOneChar.Substring(0, inputMinusOneChar.Length - 1).Trim();
                stringMeasurement = gfx.MeasureString(inputMinusOneChar + '…', font);
            } while (stringMeasurement.Width > rect.Width);
            output = inputMinusOneChar + '…';
        }
        return output;
    }
