    public class RemoveNulls
    {
        public object[][] RemoveNullItems()
        {
            object[,] items = new object[2, 2] { { null, null }, { 1, 2 } };
            IList<object[]> cleanRows = Enumerable.Empty<object[]>().ToList();
            foreach (object[] row in items)
            {
                var newRow = row.Where(item => item != null).ToArray();
                if (newRow.Any()) cleanRows.Add(newRow);
            }
            var result = cleanRows.ToArray();
            return result;
        }
    }
