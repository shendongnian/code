    interface ISortable
    {
        int Order { get; }
    }
    interface ISortableClass2
        : ISortable
    {
        // This hides the read-only member of ISortable but still satisfies the contract
        new int Order { get; set; }
    }
    class SortableClass1
        : ISortable
    {
        private readonly int order;
        public SortableClass1(int order)
        {
            this.order = order;
        }
        #region ISortable Members
        public int Order
        {
            get { return this.order; }
        }
        #endregion
    }
    class SortableClass2
        : ISortableClass2
    {
        #region ISortableClass2 Members
            public int Order { get; set; } 
        #endregion
    }
    class RunSorting
    {
        public static void Run()
        {
            // Test SortableClass1
            var list1 = new List<SortableClass1>();
            list1.Add(new SortableClass1(6));
            list1.Add(new SortableClass1(1));
            list1.Add(new SortableClass1(5));
            list1.Add(new SortableClass1(2));
            list1.Add(new SortableClass1(4));
            list1.Add(new SortableClass1(3));
            var sorted1 = SortObjects(list1);
            foreach (var item in sorted1)
            {
                Console.WriteLine("SortableClass1 order " + item.Order);
            }
            // Test SortableClass2
            var list2 = new List<SortableClass2>();
            list2.Add(new SortableClass2() { Order = 6 });
            list2.Add(new SortableClass2() { Order = 2 });
            list2.Add(new SortableClass2() { Order = 5 });
            list2.Add(new SortableClass2() { Order = 1 });
            list2.Add(new SortableClass2() { Order = 4 });
            list2.Add(new SortableClass2() { Order = 3 });
            var sorted2 = SortObjects(list2);
            foreach (var item in sorted2)
            {
                Console.WriteLine("SortableClass2 order " + item.Order);
            }
        }
        private static IEnumerable<T> SortObjects<T>(IList<T> objectsToSort) where T : ISortable
        {
            if (objectsToSort.Any(x => x.Order != 0))
            {
                return objectsToSort.OrderBy(x => x.Order);
            }
            return objectsToSort;
        }
    }
