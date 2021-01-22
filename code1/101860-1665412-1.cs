            var input = "A150[ff+1];A160;A150[ff-1]";
            var temp = new List<string>();
            foreach (var s in input.Split(';'))
            {
                temp.Add(Regex.Replace(s, "(A[0-9]*)\\[*.*", "$1"));
            }
            foreach (var s1 in temp.Distinct())
            {
                Console.WriteLine(s1);   
            }
