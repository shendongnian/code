    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    namespace WindowsFormsApplication
    {
        public partial class FormMain : Form
        {
            Random rand;
            MyObject obj;
            public FormMain()
            {
                InitializeComponent();
                rand = new Random();
                obj = new MyObject();
                propertyGrid1.SelectedObject = obj;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                obj.MyValue = rand.Next();
                obj.IsEnabled = !obj.IsEnabled;
                obj.MyText = DateTime.Now.ToString();
                propertyGrid1.Refresh();
            }
        }
        public class MyObject : INotifyPropertyChanged
        {
            private int _MyValue;
            public int MyValue
            {
                get
                {
                    return _MyValue;
                }
                set
                {
                    _MyValue = value;
                    NotifyPropertyChanged("MyValue");
                }
            }
            private string _MyText;
            public string MyText
            {
                get
                {
                    return _MyText;
                }
                set
                {
                    _MyText = value;
                    NotifyPropertyChanged("MyText");
                }
            }
            private bool _IsEnabled;
            public bool IsEnabled
            {
                get
                {
                    return _IsEnabled;
                }
                set
                {
                    _IsEnabled = value;
                    NotifyPropertyChanged("IsEnabled");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
        }
    }
