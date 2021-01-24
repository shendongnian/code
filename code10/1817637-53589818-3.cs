            int[] indexes = Enumerable.Range(0, sampleStr.Length).Where(x => sampleStr[x] == '*' || x % 39 == 0).ToArray();
            int j = 0;
  
            foreach (var position in indexes)
            {
                if (position > 0)
                {
                    sampleStr = sampleStr.Insert(position + j, Environment.NewLine);
                    j = j + 2; // increment by two since newline will take two chars 
                }
            }
