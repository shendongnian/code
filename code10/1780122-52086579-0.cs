        public void Boxify()
        {
            var lines = " If our road signs    Catch your eye          Smile        But don't forget        To buy          Burma Shave    ";
            var phrases = Regex.Split(lines.Trim(), @"\s{2,}");
            var maxTextWidth = phrases.Max(x => x.Length) + 2;
            foreach (var phrase in phrases.Select(Box))
            {
                Console.WriteLine(phrase);
                Console.ReadLine();
            }
            string Box(string phrase)
            {
                var spaceCount = maxTextWidth - phrase.Length;
                var leftSpaceCount = spaceCount / 2;
                var rightSpaceCount = (spaceCount + 1) / 2;
                return $"┎{new string('─', maxTextWidth)}┒\n" +
                    $"|{new string(' ', leftSpaceCount)}{phrase}{new string(' ', rightSpaceCount)}|\n" +
                    $"└{new string('─', maxTextWidth)}┘";
            }
        }
