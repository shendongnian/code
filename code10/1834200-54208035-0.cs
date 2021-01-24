    private class Result
    {
        public string Name { get; set; }
        public double Score { get; set; }
        public TimeSpan Time { get; set; }
        public int CorrectCount { get; set; }
        /// <summary>
        /// Returns an instance of the Result class based on a string.
        /// The string must be in the format:
        /// "Score: [score] ~[Name] -- Timer: [mm:ss] -- [numCorrect]/41"
        /// Where [score] is a valid double and [numCorrect] a valid int
        /// </summary>
        /// <param name="input">The string to parse</param>
        /// <returns>A Result with properties set from the input string</returns>
        public static Result Parse(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            var splitStrings = new[] {"Score:", " ~", " -- ", "/41"};
            var parts = input
                .Split(splitStrings, StringSplitOptions.RemoveEmptyEntries)
                .Select(item => item.Trim())
                .ToList();
            // These will hold the converted parts of the string
            double score;
            int correctCount;
            TimeSpan time;
            // Verify that the string contains 4 parts, and that the Score, Time, and
            // CorrectCount parts can be converted to the proper data type for the property
            if (parts.Count != 4 ||
                !double.TryParse(parts[0], out score) ||
                !TimeSpan.TryParseExact(parts[2], @"mm\:ss", 
                    CultureInfo.InvariantCulture, out time) ||
                !int.TryParse(parts[3], out correctCount))
            {
                throw new FormatException("input is not in a recognized format");
            }
            return new Result
            {
                Name = parts[1],
                Score = score,
                Time = time,
                CorrectCount = correctCount
            };
        }
        public override string ToString()
        {
            return $"Score:{Score} ~{Name} -- {Time.ToString(@"mm\:ss")} -- {CorrectCount}/41";
        }
    }
