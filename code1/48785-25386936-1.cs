        public List<string> FindPermutations(string input)
        {
            if (input.Length == 1)
                return new List<string> { input };
            var perms = new List<string>();
            foreach (var c in input)
            {
                var others = input.Remove(input.IndexOf(c), 1);
                perms.AddRange(FindPermutations(others).Select(perm => c + perm));
            }
            return perms;
        }
