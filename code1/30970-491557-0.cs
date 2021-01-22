    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ThreadSafeDictionary.AddItem("New Item:1", 1);
                ThreadSafeDictionary.AddItem("New Item:2", 2);
            }
        }
        public static class ThreadSafeDictionary
        {
            private static readonly Dictionary<string, int> dict = new Dictionary<string, int>();
    
            public static void AddItem(string key, int value)
            {
                lock (((IDictionary)dict).SyncRoot)
                {
                    if (!dict.ContainsKey(key))
                        dict.Add(key, value);
                }
            }
        }
    }
