    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    
    namespace BindingListExample
    {
        class Program
        {
            public ObservableCollection<MyStruct> oc = new ObservableCollection<MyStruct>();
            public System.ComponentModel.BindingList<MyStruct> bl = new BindingList<MyStruct>();
    
            public Program()
            {
                oc.Add(new MyStruct());
                oc.CollectionChanged += CollectionChanged;
    
                bl.Add(new MyStruct());
                bl.ListChanged += ListChanged;
            }
    
            void ListChanged(object sender, ListChangedEventArgs e)
            {
                //Observe when the IsActive value is changed this event is triggered.
                Console.WriteLine(e.ListChangedType.ToString());
            }
    
            void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                //Observe when the IsActive value is changed this event is not triggered.
                Console.WriteLine(e.Action.ToString());
            }
    
            static void Main(string[] args)
            {
                Program pm = new Program();
                pm.bl[0].IsActive = false;
            }
        }
    
        public class MyStruct : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private bool isactive;
            public bool IsActive
            {
                get { return isactive; }
                set
                {
                    isactive = value;
                    NotifyPropertyChanged("IsActive");
                }
            }
    
            private void NotifyPropertyChanged(String PropertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
                }
            }
        }
    }
