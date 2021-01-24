            string a = "Stuff, another thing, random stuff, snuff, Pigs are wierd, sick, Cats are dangerous, they will kill you, Cows produce milk, but horses don't";
            var output = Regex.Matches(a, "[^,]+,[^,]+,*");
            StringBuilder sb = new StringBuilder();
            foreach(Match item in output)
            {
                sb.AppendLine(item.Value.Trim(','));
            }
            Console.WriteLine(sb.ToString());
