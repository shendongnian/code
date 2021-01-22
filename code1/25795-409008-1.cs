    public partial class Form1 : Form, System.ComponentModel.INotifyPropertyChanged
    {
        //----------- implements INotifyPropertyChanged -----------
        // wish C# has this VB.NET's syntactic sugar
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged; // implements INotifyPropertyChanged.PropertyChanged 
        //----------- start of Form1  ----------
        DataSet _ds = new DataSet();
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
        
        
        void GetData()
        {
            var t = new DataTable
            {
                TableName = "beatles",
                Columns =
                {
                    {"lastname", typeof(string)},
                    {"firstname", typeof(string)},
                    {"middlename", typeof(string)}
                }
            };
            t.Rows.Add("Lennon", "John", "Winston");
            t.Rows.Add("McCartney", "James", "Paul");
            t.Columns["middlename"].DefaultValue = "";
            _ds.Tables.Add(t);            
        }
        string _hey = "";
        public string Hey 
        { 
            set 
            {
                if (value != _hey)
                {
                    _hey = value;
                    NotifyPropertyChanged("Hey");
                }
            } 
            get 
            {                
                
                return _hey;  
            } 
        }
        public Form1()
        {
            InitializeComponent();
            var tLastname = new TextBox { Top = 100 };
            var tFirstname = new TextBox { Top = 130 };
            this.Controls.Add(tLastname);
            this.Controls.Add(tFirstname);
            GetData();
            tLastname.DataBindings.Add("Text", _ds.Tables["beatles"], "lastname");
            tFirstname.DataBindings.Add("Text", _ds.Tables["beatles"], "firstname");
            this.DataBindings.Add("Hey", _ds.Tables["beatles"], "middlename");
            _ds.AcceptChanges();
            MessageBox.Show("1st:Has Changes = " + _ds.HasChanges().ToString());
            var bDetectChanges = new Button { Top = 160, Text = "Detect Changes" };
            bDetectChanges.Click +=
                delegate
                {
                    this.BindingContext[_ds.Tables["beatles"]].EndCurrentEdit();
                    MessageBox.Show("2nd:Has Changes = " + (_ds.GetChanges() != null).ToString());
                };
            this.Controls.Add(bDetectChanges);
        }
    }
