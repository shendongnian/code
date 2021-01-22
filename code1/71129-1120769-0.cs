        class ItemAB
        {
            public ItemAB(ItemA a, ItemB b)
            {
                FieldA1 = a.FieldA1;
                FieldA2 = a.FieldA2;
                FieldB1 = b.FieldB1;
                FieldB2 = b.FieldB2;
            }
            public int FieldA1 { get; private set; }
            public int FieldA2 { get; private set; }
            public int FieldB1 { get; private set; }
            public int FieldB2 { get; private set; }
        }
        var result = from itemA in TableA 
                     join itemB in TableB on itemA.ID equals itemB.ID
                     select new ItemAB(itemA, itemB);
