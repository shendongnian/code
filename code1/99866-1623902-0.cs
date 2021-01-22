    public partial class Form1 : Form
    {
        public Person TheBoss { get; set; }
        public Form1()
        {
            InitializeComponent();
            TheBoss = new Person { FirstName = "John" };
            textBox1.DataBindings.Add("Text", this, "TheBoss.FirstName");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TheBoss.FirstName = "Mike";
        }
        public class Person : INotifyPropertyChanged
        {
            private string firstName;
            public string FirstName
            {
                get 
                { 
                    return firstName; 
                }
                set 
                { 
                    firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            #endregion
        }
    }
