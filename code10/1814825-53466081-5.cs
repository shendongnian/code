        public static List<Color> Foo3(List<int> data, List<int> numbersToSeekFor, List<Color> colorsToAssign)
        {
            if (data?.Any() != true || numbersToSeekFor?.Any() != true || colorsToAssign?.Count != data.Count)
            {
                return new List<Color>();
            }
            List<Color> colors = data
                                 .Select(d => numbersToSeekFor.IndexOf(d))
                                 .Where(i => i > -1 && i < colorsToAssign.Count)
                                 .Select(index => colorsToAssign[index])
                                 .ToList();
            return colors;
        }
