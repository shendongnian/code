    var regex = new Regex(@"(^[a-z])([a-z0-9:]*)(/)([a-z0-9]+)([\\])([a-z]+)");
            var counter = 0;
            for (var c = 0; c < command.Length; c++)
            {
                var isMatched = regex.Match(string.Join(string.Empty, command.Skip(c)));
                if (isMatched.Success)
                {
                    counter += isMatched.Groups.Last().Value.ToCharArray().Length;
                }
            }
            return counter;
