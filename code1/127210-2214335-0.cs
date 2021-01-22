    sealed class MyBindingList<T> : BindingList<T>
    {
        public event EventHandler MyAddingNew;
        public MyBindingList(IList<T> collection)
            : base(collection)
        {
            //hook so that when BindingList.AddingNew is fired
            //it is chained to our new event
            base.AddingNew += MyBindingList_AddingNew;
        }
        public void MyBindingList_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (MyAddingNew != null)
                MyAddingNew(sender, e);
        }
        public void RegisterEvents(MyBindingList<T> src)
        {
            //this is where you assign src events to your new list
            this.MyAddingNew = src.MyAddingNew;
        }
    } 
