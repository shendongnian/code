    var pattern = @"#\D*";
            foreach (var sharp in tweet)
            {
                var match = Regex.Match(pattern, sharp);
                if (match.Success)
                    Console.WriteLine(Regex.Replace(sharp, match.Value, "#" + match.Value, RegexOptions.Singleline));
                else
                    Console.WriteLine(sharp);
            }
