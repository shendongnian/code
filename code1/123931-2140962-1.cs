    using System.Collections;
    using System.Collections.Generic;
    using System.Windows;
    
    namespace TwoColsDemo
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                Hashtable sman = new Hashtable();
                sman.Add("Key1", "Value1");
                sman.Add("Key2", "Value2");
    
                Data = new List<DictionaryEntry>();
    
                IEnumerator enumerator = sman.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DictionaryEntry entry = (DictionaryEntry)enumerator.Current;
                    Data.Add(entry);
                }
    
                DataContext = this;
            }
    
            public List<DictionaryEntry> Data { get; private set; }
        }
    }
