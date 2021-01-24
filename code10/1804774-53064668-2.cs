     public class Student : NotifiableBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }
        private string lName;
        public string LName
        {
            get { return lName; }
            set
            {
                lName = value;
                NotifyPropertyChanged();
            }
        }
        private string fName;
        public string FName
        {
            get { return fName; }
            set
            {
                fName = value;
                NotifyPropertyChanged();
            }
        }
        public Student(string name, string lName, string fName)
        {
            this.name = name;
            this.lName = lName;
            this.fName = fName;
        }
    }
