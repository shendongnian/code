      int[] ParseIntArray(string input, bool validateRequired)
      {
         if (validateRequired)
         {
            string[] split = input.Split();
            List<int> result = new List<int>(split.Length);
            int parsed;
            for (int inputIdx = 0; inputIdx < split.Length; inputIdx++)
            {
               if (int.TryParse(split[inputIdx], out parsed))
                  result.Add(parsed);
            }
            return result.ToArray();
         }
         else
            return (from i in input.Split()
                    select int.Parse(i)).ToArray();
      }
