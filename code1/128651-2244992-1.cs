    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Data;
    
    namespace CurrentChangedTest
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                _zoneList.Add(new KeyValuePair<int, string>(0, "zone 0"));
                _zoneList.Add(new KeyValuePair<int, string>(1, "zone 1"));
                _zoneList.Add(new KeyValuePair<int, string>(2, "zone 2"));
    
                ZoneCollView = new CollectionView(_zoneList);
                ZoneCollView.CurrentChanged +=
                    delegate { Debug.WriteLine(ZoneCollView.CurrentItem); };
    
                DataContext = this;
            }
    
            public ICollectionView ZoneCollView { get; set; }
    
            private List<KeyValuePair<int, string>> _zoneList = new List<KeyValuePair<int, string>>();
        }
    }
