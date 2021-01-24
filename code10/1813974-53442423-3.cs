    public partial class Listbox : Window
    {
        public Listbox()
        {
            InitializeComponent();
            User newUser = new User();
            newUser.Title = "John Doe";
            newUser.Name = "Dr.";
            this.myUserList.Items.Add(newUser.Title + newUser.Name);
        }
        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
          User newUser = new User();
            newUser.Title = myTitle.Text;
            newUser.Name = myName.Text;
            myUserList.Items.Add(newUser.Name + " " + newUser.Title );
	    myTitle.Text=String.Empty;
            myName.Text=String.Empty;        
	}
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            myUserList.Items.RemoveAt(myUserList.Items.IndexOf(myUserList.SelectedItem));
        }
    }
    public class User
    {
        public string name;
        public string title;
        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("name");
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("title");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
