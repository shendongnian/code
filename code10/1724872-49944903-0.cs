    public class OrderModel : INotifyPropertyChanged
    { 
         private OrderCase order;
         public OrderCase Order
         {
            get
            {
                return order;
            }
            set
            {
                if (value != order) { IsDirty = true; }
                order = value;
    
                this.RaisePropertyChanged("Order");
            }
         }
        private bool dirty;
        public bool Dirty
        {
            get
            {
                return dirty;
            }
            set
            {
                dirty = value;
            }
        }
    }
