    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private readonly Dictionary<String, int> localDict1 = new Dictionary<String, int>();
            private readonly Dictionary<String, int> localDict2 = new Dictionary<String, int>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //use two different dictionaries just to show it working
                if (localDict1 != null)
                {
                    ThreadSafeDictionary<int>.AddItem(localDict1, "New Item :1", 1);
                    ThreadSafeDictionary<int>.AddItem(localDict1, "New Item :2", 2);
                }
                if (localDict2 != null)
                    ThreadSafeDictionary<int>.AddItem(localDict2, "New Item :1", 1);
            }
        }
    
        public static class ThreadSafeDictionary<T>
        {
            public static void AddItem(Dictionary<String, T> dict, String key, T value)
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
                        MessageBox.Show(String.Format("Value {0} is already present and equates to {1}", key, result));
                    }
                }
            }
        }
    }
