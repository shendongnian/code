    public class MyPage : Page
    {
        private void Setup()
        {
            Items = ...;
            RelatedItems = ...;
        }
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ReadOnlyCollection<data>), typeof(MyPage),new PropertyMetadata(false));
        public ReadOnlyCollection<data> Items
        {
            get { return (ReadOnlyCollection<data>)this.GetValue(ItemsProperty ); }
            set { this.SetValue(ItemsProperty , value); } 
        }
        public static readonly DependencyProperty RelatedItemsProperty =
            DependencyProperty.Register("RelatedItems", typeof(ReadOnlyCollection<data>), typeof(MyPage),new PropertyMetadata(false));
        public ReadOnlyCollection<data> RelatedItems
        {
            get { return (ReadOnlyCollection<data>)this.GetValue(RelatedItemsProperty ); }
            set { this.SetValue(RelatedItemsProperty , value); } 
        }
    }
