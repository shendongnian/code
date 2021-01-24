    public class MyCommonValues
    {
      public static string SharedText { get; set; }
    }
    class Page1ViewModel : Notifier
    {
        private string username;
        public string UserName
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("UserName");
                OnUserNameChanged(); // added to your code
            }
        }
        // following is an addition to your code
        void OnUserNameChanged()
        {
          MyCommonValues.SharedText = UserName;
        }
    }
    class Page2ViewModel : Notifier
    {
        // following is an addition to your code
        public Page2ViewModel()
        {
          TextBox_Name = MyCommonValues.SharedText;
        }
        private string textbox_name;
        public string TextBox_Name
        {
            get { return textbox_name; }
            set
            {
                textbox_name = value;
                OnPropertyChanged("TextBox_Name");
            }
        }
    }
