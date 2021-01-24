        public static List<Color> AssignColours(List<int> data, List<Color> coloursToAssign)
        {
            var result = new List<Color>();
            var map    = new Dictionary<int, Color>();
            int n      = 0;
            foreach (var datum in data)
            {
                if (!map.TryGetValue(datum, out var colour))
                {
                    // Next line will throw exception if number of distinct numbers
                    // is greater than length of coloursToAssign.
                    colour = coloursToAssign[n++];
                    map[datum] = colour;
                }
                result.Add(colour);
            }
            return result;
        }
