    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    namespace TextBindingTest
    {
        public partial class Form1 : Form
        {
            private readonly CountList<string> _List =
                new CountList<string>(new List<string> { "a", "b", "c" });
            public Form1()
            {
                InitializeComponent();
                BindAll();
            }
            private void BindAll()
            {
                var binding = new Binding("Text", _List, "Count", true);
                binding.Format += (sender, e) => e.Value = string.Format("{0} items", e.Value);
                label1.DataBindings.Add(binding);
            }
            private void addToList_Click(object sender, EventArgs e)
            {
                _List.Add("a");
            }
            private void closeButton_Click(object sender, EventArgs e)
            {
                Close();
            }
        }
        public class CountList<T> : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            private void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                var handler = PropertyChanged;
                handler(this, e);
            }
            private ICollection<T> List { get; set; }
            public int Count { get { return List.Count; } }
            public CountList(ICollection<T> list)
            {
                List = list;
            }
            public void Add(T item)
            {
                List.Add(item);
                OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            }
        }
    }
