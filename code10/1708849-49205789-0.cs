    string bs = "The foo or the bar 100. A large machine 200.";
            string[] dotspl = bs.Split(new string[]{". "}, StringSplitOptions.None);
            string pt1 = dotspl[0].Split(new string[]{" or "}, StringSplitOptions.None)[1];
            string pt2 = dotspl[1];
            Console.WriteLine(pt1 + " and " + pt2);
