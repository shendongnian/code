        private List<string> GetCustomPermutations(int count)
        {
            if(count < 1)
            {
                return new List<string>();
            }
            List<string> firstEntries = new List<string>();
            List<string> secondEntries = new List<string>();
            // Create list of firstEntries = {A1, B1, ...} and secondEntries = {A2, B2, ...} from count
            for (int i = 0; i < count; i++)
            {
                firstEntries.Add((char)('A' + i) + "1");
                secondEntries.Add((char)('A' + i) + "2");
            }
            // Get Powerset of second Entries
            string[][] FullPowerSet = FastPowerSet(secondEntries.ToArray());
            List<string> CustomSet = new List<string>();
            foreach (string firstEntry in firstEntries)
            {
                for (int i = 0; i < FullPowerSet.Length; i++)
                {
                    // join the second array dimension to create the appended entry
                    string appendedEntry = string.Join("", FullPowerSet[i]);
                    
                    // Avoid adding the firstentry char to the appended aswell
                    if (appendedEntry.Contains(firstEntry[0]))
                    {
                        continue;
                    }
                    CustomSet.Add(firstEntry + appendedEntry);
                }
            }
            return CustomSet;
        }
        // Create a powerset of every input array, see https://stackoverflow.com/questions/19890781/creating-a-power-set-of-a-sequence
        public static T[][] FastPowerSet<T>(T[] seq)
        {
            var powerSet = new T[1 << seq.Length][];
            powerSet[0] = new T[0]; // starting only with empty set
            for (int i = 0; i < seq.Length; i++)
            {
                var cur = seq[i];
                int count = 1 << i; // doubling list each time
                for (int j = 0; j < count; j++)
                {
                    var source = powerSet[j];
                    var destination = powerSet[count + j] = new T[source.Length + 1];
                    for (int q = 0; q < source.Length; q++)
                        destination[q] = source[q];
                    destination[source.Length] = cur;
                }
            }
            return powerSet;
        }
