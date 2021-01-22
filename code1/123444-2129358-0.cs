        public void LoopRecursively(Stack<int> valuesSoFar, int dimensions)
        {
            for (var i = 0; SumOf(valuesSoFar) + i <= dimensions; i++)
            {
                valuesSoFar.Push(i);
                if (valuesSoFar.Count == dimensions)
                {
                    Console.WriteLine(StringOf(valuesSoFar));
                }
                else
                {
                    LoopRecursively(valuesSoFar, dimensions);
                }
                valuesSoFar.Pop();
            }
        }
        private int SumOf(IEnumerable<int> values)
        {
            return values.Sum(x => x);
        }
        private string StringOf(IEnumerable<int> values)
        {
            return string.Join(" ", values.Reverse().Select(x => x.ToString()).ToArray());
        }
