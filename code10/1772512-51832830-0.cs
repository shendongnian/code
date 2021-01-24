        private static List<NumberCount> findMostCommon(List<int> integers)
        {
            List<NumberCount> answers = new List<NumberCount>();
            int[] mostCommon = new int[_Max];
            int max = 0;
            for (int i = 1; i < integers.Count; i++)
            {
                int iValue = integers[i];
                mostCommon[iValue]++;
                int intVal = mostCommon[iValue];
                if (intVal > 1)
                {
                    if (intVal > max)
                    {
                        max++;
                        answers.Clear();
                        answers.Add(new NumberCount(iValue, max));
                    }
                    else if (intVal == max)
                    {
                        answers.Add(new NumberCount(iValue, max));
                    }
                }
            }
            if (answers.Count < 1)
                answers.Add(new NumberCount(0, -100)); // This -100 Occurrecnces value signifies that all values are equal.
            return answers;
        }
