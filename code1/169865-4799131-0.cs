    public class MyViewModel
    {
        // your view model code...
        // ........................
        // this object better be more strongly typed
        private object _mySelectedItem; 
        public object MySelectedItem
        {
            get { return _mySelectedItem; }
            set { 
                  _mySelectedItem = value;
                                    
                  // the following method will handle the changed item. Problem solved              
                  HandleTheNewChangedItem(value);
                }
        }
    }
