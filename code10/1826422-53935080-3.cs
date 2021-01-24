    public sealed partial class MainPage : Page
        {
            public List<item> line_items = new List<item>();
            public MainPage()
            {
                for (var i = 0; i < 10; i++)
                    line_items.Add(new item() { is_checked = false, value = "item" + i });
                this.InitializeComponent(); 
            }
    
            private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                foreach(var item in line_items)
                    item.is_checked = false;
                line_items[(sender as ListView).SelectedIndex].is_checked = true;
            }
        }
        public class item : INotifyPropertyChanged
        {
            private bool? _is_checked;
            private string _value;
    
            public bool? is_checked
            {
                get { return _is_checked; }
                set
                {
                    _is_checked = value;
                    RaisePropertyChanged(nameof(is_checked));
                }
            }
    
            public string value
            {
                get { return _value; }
                set
                {
                    _value = value;
                    RaisePropertyChanged(nameof(value));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RaisePropertyChanged(string name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
        }
