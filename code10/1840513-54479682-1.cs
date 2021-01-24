    namespace Foo.Controls
    {
        public class SpottedView : ListView
        {
            ObservableCollection<string> items;
    
            public SpottedView() : base()
            {
                items = new ObservableCollection<string>();
                ItemsSource = items;
                items.CollectionChanged += onItemsChanged;
    
                // TODO: test purposes, remove later
                var autoEvent = new AutoResetEvent(false);
                var stateTimer = new Timer(onTimer, autoEvent, 1000, 2000);
            }
    
            void onItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    HeightRequest = RowHeight * items.Count;
                    InvalidateMeasure();
                });
            }
    
            // TODO test purposes, remove later.
            void onTimer(object state)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (items.Count < 2)
                    {
                        items.Add("Blah");
                    }
                    else
                    {
                        items.Clear();
                    }
                });
            }
        }
    }
