       public class MyCollectionViewModel : ObservableCollection<SomeObject>
        {
            public MyCollectionViewModel ()
            {
                TotalRow = new SomeObject() { Name = "Total" };
                base.Add(TotalRow );
            }
            public new void Add(SomeObject item)
            {
                int i = base.Count -1;
                base.InsertItem(i, item);
            }
            private SomeObject TotalRow { get; set; }
        }
