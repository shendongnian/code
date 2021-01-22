    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private static readonly Dictionary<String, int> localDict = new Dictionary<String, int>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (localDict != null)
                {
                    ThreadSafeDictionary.AddItem(localDict, "New Item:1", 1);
                    ThreadSafeDictionary.AddItem(localDict, "New Item:2", 2);
                }
            }
        }
    
        public static class ThreadSafeDictionary
        {
            public static void AddItem(Dictionary<String, int> dict, String key, int value)
            {
                if (dict != null)
                {
                    lock (((IDictionary)dict).SyncRoot)
                    {
                        if (!dict.ContainsKey(key))
                            dict.Add(key, value);
                    }
                }
            }
        }
    }
