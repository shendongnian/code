    public class MyContainer : StackPanel
    {
       public MyContainer()
       {
          this.ItemsSource = MyCollection;
       }
       
       ObservableCollection<UIElement> myCollection;
       public ObservableCollection<UIElement> MyCollection
       {
          get
          {
             if (myCollection == null)
             {
                 myCollection = new ObservableCollection<UIElement>();
                 myCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(myCollection_CollectionChanged);
             }
             return myCollection;
       }
       
       void myCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
       {
           foreach (UIElement removed in e.OldItems)
           {
              if (added is TextBox)
                 (added as TextBox).TextChanged -= new Removeyoureventhandler here...
              if (added is someotherclass)
                 (added as someotherclass).someotherevent += Removesomeothereventhandler here...              
           }
           
           foreach (UIElement added in e.NewItems)
           {
              if (added is TextBox)
                 (added as TextBox).TextChanged += new Addyoureventhandler here...
              if (added is someotherclass)
                 (added as someotherclass).someotherevent += Addsomeothereventhandler here...
           }
        
    }
