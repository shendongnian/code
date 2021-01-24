        public static List<List<MyClass>> MyConvertLinq(List<List<List<MyClass>>> items)
        {
            var allItems = items.SelectMany(m => m).ToList();
            return allItems;
        }
