    using System;
    using System.Collections.ObjectModel;  // Add reference to WindowsBase
    using System.Collections.Specialized;
    using System.Reflection;
    
    namespace ConsoleApplication1 {
      class Program {
        static void Main(string[] args) {
          var coll = new ObservableCollection<int>();
          coll.CollectionChanged += coll_CollectionChanged;
          coll.Add(42);
          FieldInfo fi = coll.GetType().GetField("CollectionChanged", BindingFlags.NonPublic | BindingFlags.Instance);
          NotifyCollectionChangedEventHandler handler = fi.GetValue(coll) as NotifyCollectionChangedEventHandler;
          handler.Invoke(coll, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    
        static void coll_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
          Console.WriteLine("Changed {0}", e.Action);
        }
      }
    }
