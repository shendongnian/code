    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private readonly Dictionary<string, int> localDict1 = new Dictionary<string, int>();
            private readonly Dictionary<string, string> localDict2 = new Dictionary<string, string>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // use two different dictionaries just to show it working with
                // different data types (i.e. we could use class objects too)
                if (localDict1 != null)
                {
                    ThreadSafeDictionary<int>.AddItem(localDict1, "New Item :1", 1);
                    ThreadSafeDictionary<int>.AddItem(localDict1, "New Item :2", 2);
                }
                if (localDict2 != null)
                    ThreadSafeDictionary<string>.AddItem(localDict2, "New Item :1", "this is not a number");
            }
        }
    
        public static class ThreadSafeDictionary<T>
        {
            public static void AddItem(Dictionary<string, T> dict, string key, T value)
            {
                if (dict == null) return;
                lock (((IDictionary)dict).SyncRoot)
                {
                    if (!dict.ContainsKey(key))
                        dict.Add(key, value);
                    else
                    {
                        // awful and we'd never ever show a message box in real life - however!!
                        var result = dict[key];
                        MessageBox.Show(String.Format("Key '{0}' is already present with a value of '{1}'", key, result));
                    }
                }
            }
        }
    }
