       public class MyCollectionViewModel : ObservableCollection<SomeObject>
        {
            private readonly SomeObject _totalRow;
            public MyCollectionViewModel ()
            {
                _totalRow = new SomeObject() { IsTotalRow = true; };
                base.Add(_totalRow );
            }
            public new void Add(SomeObject item)
            {
                int i = base.Count -1;
                base.InsertItem(i, item);
            }
        }
