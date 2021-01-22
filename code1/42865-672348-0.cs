    namespace UnitTests
    {
        using System.Collections.Generic;
        using System.Collections.ObjectModel;
        using System.Collections.Specialized;
        using System.ComponentModel;
        using System.Linq;
    
        public class ViewModel : INotifyPropertyChanged
        {
            private string name;
    
            public ViewModel()
            {
                this.Stores = new ObservableCollection<string>();
    
                this.Stores.CollectionChanged += new NotifyCollectionChangedEventHandler(this.Stores_CollectionChanged);
    
                // TODO: Add code to retreive the stores collection
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            #endregion
    
            public ObservableCollection<string> Stores { get; private set; }
    
            public IEnumerable<string> FilteredStores { get; private set; }
    
            public string Name 
            { 
                get
                {
                    return this.name;
                }
    
                set
                {
                    this.name = value;
    
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                    }
    
                    this.UpdateFilteredStores();
                }
            }
    
            private void Stores_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                this.UpdateFilteredStores();
            }
    
            private void UpdateFilteredStores()
            {
                this.FilteredStores = from store in this.Stores
                                      where store.Contains(this.Name)
                                      select store;
    
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("FilteredStores"));
                }
            }
        }
    }
