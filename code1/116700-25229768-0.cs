    public static class ColorHelpers
    {
        public static bool TryGetConsoleColor(Color color, out ConsoleColor consoleColor)
        {
            foreach (PropertyInfo property in typeof (Color).GetProperties())
            {
                Color c = (Color) property.GetValue(null);
    
                if (color == c)
                {
                    int index = Array.IndexOf(Enum.GetNames(typeof (ConsoleColor)), property.Name);
                    if (index != -1)
                    {
                        consoleColor = (ConsoleColor) Enum.GetValues(typeof (ConsoleColor)).GetValue(index);
                        return true;
                    }
                }
            }
            consoleColor = default (ConsoleColor);
            return false;
        }
    }
