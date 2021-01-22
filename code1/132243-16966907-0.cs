    public static class DataExtensions
    {
        public static bool AreAllCellsEmpty(this DataRow row)
        {
            var itemArray = row.ItemArray;
            if(itemArray==null)
                return true;
            return itemArray.All(x => string.IsNullOrWhiteSpace(x.ToString()));            
        }
    }
