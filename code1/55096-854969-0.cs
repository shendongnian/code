    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Dictionary<string, decimal> prices = new Dictionary<string, decimal>();
            prices.Add("foo", 123.45M);
            prices.Add("bar", 678.90M);
    
            Application.EnableVisualStyles();
            Form form = new Form();
            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            form.Controls.Add(dgv);
            dgv.DataSource = prices.ToBindingList();
            Application.Run(form);
        }
    
        public static BindingList<Pair<TKey, TValue>>
            ToBindingList<TKey, TValue>(this IDictionary<TKey, TValue> data)
        {
            return new DictionaryBindingList<TKey, TValue>(data);
        }
        public sealed class Pair<TKey, TValue>
        {
            private readonly TKey key;
            private readonly IDictionary<TKey, TValue> data;
            public Pair(TKey key, IDictionary<TKey, TValue> data)
            {
                this.key = key;
                this.data = data;
            }
            public TKey Key { get { return key; } }
            public TValue Value
            {
                get
                {
                    TValue value;
                    data.TryGetValue(key, out value);
                    return value;
                }
                set { data[key] = value; }
            }
        }
        private class DictionaryBindingList<TKey, TValue>
            : BindingList<Pair<TKey, TValue>>
        {
            private readonly IDictionary<TKey, TValue> data;
            public DictionaryBindingList(IDictionary<TKey, TValue> data)
            {
                this.data = data;
                foreach (TKey key in data.Keys)
                {
                    Add(new Pair<TKey, TValue>(key, data));
                }
            }
        }
    }
