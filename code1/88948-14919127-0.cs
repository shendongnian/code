    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel; // ObservableCollection
    using System.ComponentModel; // INotifyPropertyChanged
    using System.Collections.Specialized; // NotifyCollectionChangedEventHandler
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ObservableCollectionTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // ATTN: Please note it's a "TrulyObservableCollection" that's instantiated. Otherwise, "Trades[0].Qty = 999" will NOT trigger event handler "Trades_CollectionChanged" in main.
                // REF: http://stackoverflow.com/questions/8490533/notify-observablecollection-when-item-changes
                TrulyObservableCollection<Trade> Trades = new TrulyObservableCollection<Trade>();
                Trades.Add(new Trade { Symbol = "APPL", Qty = 123 });
                Trades.Add(new Trade { Symbol = "IBM", Qty = 456});
                Trades.Add(new Trade { Symbol = "CSCO", Qty = 789 });
    
                Trades.CollectionChanged += Trades_CollectionChanged;
                Trades.ItemPropertyChanged += PropertyChangedHandler;
                Trades.RemoveAt(2);
    
                Trades[0].Qty = 999;
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadLine();
    
                return;
            }
    
            static void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine(DateTime.Now.ToString() + ", Property changed: " + e.PropertyName + ", Symbol: " + ((Trade) sender).Symbol + ", Qty: " + ((Trade) sender).Qty);
                return;
            }
    
            static void Trades_CollectionChanged(object sender, EventArgs e)
            {
                Console.WriteLine(DateTime.Now.ToString() + ", Collection changed");
                return;
            }
        }
    
        #region TrulyObservableCollection
        public class TrulyObservableCollection<T> : ObservableCollection<T>
            where T : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler ItemPropertyChanged;
    
            public TrulyObservableCollection()
                : base()
            {
                CollectionChanged += new NotifyCollectionChangedEventHandler(TrulyObservableCollection_CollectionChanged);
            }
    
            void TrulyObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.NewItems != null)
                {
                    foreach (Object item in e.NewItems)
                    {
                        (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
                    }
                }
                if (e.OldItems != null)
                {
                    foreach (Object item in e.OldItems)
                    {
                        (item as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                    }
                }
            }
    
            void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                NotifyCollectionChangedEventArgs a = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
                OnCollectionChanged(a);
    
                if (ItemPropertyChanged != null)
                {
                    ItemPropertyChanged(sender, e);
                }
            }
        }
        #endregion
    
        #region Sample entity
        class Trade : INotifyPropertyChanged
        {
            protected string _Symbol;
            protected int _Qty = 0;
            protected DateTime _OrderPlaced = DateTime.Now;
    
            public DateTime OrderPlaced
            {
                get { return _OrderPlaced; }
            }
    
            public string Symbol
            {
                get
                {
                    return _Symbol;
                }
                set
                {
                    _Symbol = value;
                    NotifyPropertyChanged("Symbol");
                }
            }
    
            public int Qty
            {
                get
                {
                    return _Qty;
                }
                set
                {
                    _Qty = value;
                    NotifyPropertyChanged("Qty");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged(String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    #endregion
    }
