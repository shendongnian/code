    internal class StackTestCases : IEnumerable
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new LinkedListStack());
                yield return new TestCaseData(new ArrayStack());
            }
        }
        /// <inheritdoc />
        public IEnumerator GetEnumerator()
        {
            return TestCases.GetEnumerator();
        }
    }
