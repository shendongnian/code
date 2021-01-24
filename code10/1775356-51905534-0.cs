    public static class ArrayListExtensions
    {
        public static int? BinarySearchNullable(this ArrayList list, object searchValue)
        {
            int index = list.BinarySearch(searchValue);
            return index != -1 ? (int?)index : null;
        }
    }
