     string text = System.IO.File.ReadAllText(@"C:\Users\me\Desktop\text.txt");
     string[] weekDays = {"Mon","Tue","Wed","Thu","Fri"}
     for (int i = 0; i < weekDays.Length; i ++)
            {
                 Console.WriteLine (new Regex(weekdays[i]).Matches(text).Count);
            }
