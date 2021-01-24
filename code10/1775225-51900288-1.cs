    public class RemoveNulls
    {
        [Test]
        public void RemoveNullItems()
        {
            var items = new object[][] { new object[] { null, null }, new object[] { 1, 2 } };
            var cleanRows = new List<object[]>();
            foreach (object[] row in items)
            {
                var newRow = row.Where(item => item != null).ToArray();
                if (newRow.Any()) cleanRows.Add(newRow);
            }
            var result = cleanRows.ToArray();
        }
    }
