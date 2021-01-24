    public class User //Custom generic class
    {
        public int _Id { get; set; }
        public string _Name { get; set; }
    }
    public class Functions
    {
        public static List<User> PopulateComboboxWithUsers()
        {
            List<User> list = new List<User>();
            foreach(var something in somethingBig) //You can change this if you re reading form XML with it's variables or something else
            {
                list.Add(new User { _Id = something.Id, _Name = something.Name };
            }
            return list;
        }
    }
    public class Settings
    {
        public Settings()
        {
            InitializeComponents();
            comboBox1.DataSource = Functions.PopulateComboboxWithUser();
            comboBox1.DisplayMember = "_Name";
            comboBox1.ValueMember = "_Id";
        }
    }
