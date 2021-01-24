    public class GetTestData : DataAttribute
    {
        private List<object[]> _data = new List<object[]>();
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
                  throw new ArgumentNullException(testMethod.Name);
            _data.Add(new object[] { 10 });
            return _data;
        }
}
