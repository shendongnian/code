     void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
             
                var index = this.IndexOf((T)sender);
                this.RemoveAt(index);
                this.Insert(index, (T)sender);
                
                var a = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, sender);
                OnCollectionChanged(a);
             
        }
 
