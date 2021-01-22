    using System.ComponentModel;
    public class Example
    {
        BindingList<Foo> _collection;
    
        public Example()
        {
            _collection = new BindingList<Foo>();
            _collection.ListChanged += Collection_ListChanged;
        }
    
        void Collection_ListChanged(object sender, ListChangedEventArgs e)
        {
            MessageBox.Show(e.ListChangedType.ToString());
        }
    
    }
