            string strMyString = "4654564-|@$@|-Jennifer Austin    -$@%@$-646565546-|@$@|-Dutchin Henry LLC    -$@%@$-444309386-|@$@|-Winston Cooper LLC   ";
            var subStrings = strMyString.Split('-').ToList();
            var newSubstrings = new List<string>();
            subStrings.ForEach(substring => newSubstrings.Add(substring.Trim(' ')));
            var newString = string.Join("-",newSubstrings);
            Console.WriteLine(newString);
