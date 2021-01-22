        public static ICollection<int> GetAllPermutations(int input, int outputLength)
        {
            result = new List<string>();
            MakePermutations(input.ToString().ToCharArray(), string.Empty, outputLength);
            return result.Select(m => int.Parse(m)).ToList<int>();
        }
