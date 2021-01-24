    class MySortableColumn<TDisplayedProperty> : DataGridViewColumn 
       // or whatever column class you are using
    {
        public Expression<Func<MyDisplayedItem, TDisplayedProperty>> SortKeySelector{get;set;}
    }
