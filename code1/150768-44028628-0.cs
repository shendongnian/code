    public static double GetTotalHours(String s)
        {
            bool isNegative = false;
            if (s.StartsWith("-"))
                isNegative = true;
            String[] splitted = s.Split(':');
            int hours = GetNumbersAsInt(splitted[0]);
            int minutes = GetNumbersAsInt(splitted[1]);
            if (isNegative)
            {
                hours = hours * (-1);
                minutes = minutes * (-1);
            }
            TimeSpan t = new TimeSpan(hours, minutes, 0);
            return t.TotalHours;
        }
    public static int GetNumbersAsInt(String input)
            {
                String output = String.Empty;
                Char[] chars = input.ToCharArray(0, input.Length);
                for (int i = 0; i < chars.Length; i++)
                {
                    if (Char.IsNumber(chars[i]) == true)
                        output = output + chars[i];
                }
                return int.Parse(output);
            }
