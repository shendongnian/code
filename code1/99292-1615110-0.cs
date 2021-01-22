        int num = 1234567890;
        int [] arrDigits = Array.ConvertAll<string, int>(
            System.Text.RegularExpressions.Regex.Split(num.ToString(), @"(?!^)(?!$)"),
            str => int.Parse(str)
            );
        // resulting array is [1,2,3,4,5,6,7,8,9,0]
