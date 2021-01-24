    static int[][] arrays = new[]
    {
        new[] {090, 010, 002, 007, 310, 104, 048, 610, 720},
        new[] {456, 010, 002, 007, 087, 011, 345, 547, 800},
        new[] {004, 089, 870, 011, 345, 547, 800, 001, 002}
    };
    
    static void Main()
    {
        SequentedArray[] sequentedArrays = arrays.Select(array => new SequentedArray(array)).ToArray();
    
        foreach (var baseSequentedArray in sequentedArrays)
        {
            foreach (var comparisonSequentedArray in sequentedArrays)
            {
                if(baseSequentedArray == comparisonSequentedArray) continue;
    
                var sameSequences = baseSequentedArray.FindSameSequences(comparisonSequentedArray);
                foreach (var sameSequence in sameSequences)
                {
                    Console.WriteLine(String.Join(", ", sameSequence.GetValues(baseSequentedArray.Array)));
                }
            }
        }
    }
    
    class SequentedArray
    {
        public int[] Array { get; private set; }
        public List<Sequence> Sequences { get; private set; }
    
        public SequentedArray(int[] array)
        {
            Array = array;
            Sequences = new List<Sequence>();
    
            for (int endIndex = 1; endIndex < array.Length; endIndex++)
            {
                int sum = array[endIndex];
                for (int startIndex = endIndex - 1; startIndex >= 0; startIndex--)
                {
                    sum += array[startIndex];
                    Sequences.Add(new Sequence(startIndex, endIndex, sum));
                }
            }
        }
    
        public IEnumerable<Sequence> FindSameSequences(SequentedArray comparison)
        {
            var sameSequences = new List<Sequence>();
            foreach (var sequence in Sequences)
            {
                foreach (var comparisonSequence in comparison.Sequences)
                {
                    if (sequence.Sum == comparisonSequence.Sum &&
                        sequence.GetValues(Array).SequenceEqual(comparisonSequence.GetValues(comparison.Array)))
                    {
                        var smallerSequences = sameSequences.Where(existing => sequence.Covers(existing)).ToList();
                        foreach (var smallerSequence in smallerSequences)
                        {
                            sameSequences.Remove(smallerSequence);
                        }
                        sameSequences.Add(sequence);
                    }
                }
            }
    
            return sameSequences;
        }
    }
    
    class Sequence
    {
        public int StartIndex { get; private set; }
        public int EndIndex { get; private set; }
        public int Sum { get; private set; }
    
        public Sequence(int startIndex, int endIndex, int sum)
        {
            StartIndex = startIndex;
            EndIndex = endIndex;
            Sum = sum;
        }
    
        public IEnumerable<int> GetValues(int[] array)
        {
            for (int i = StartIndex; i <= EndIndex; i++)
            {
                yield return array[i];
            }
        }
    
        public bool Covers(Sequence comparison)
        {
            return StartIndex <= comparison.StartIndex && EndIndex >= comparison.EndIndex;
        }
    }
