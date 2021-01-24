        public void yourFormLoadMethod()
        {
            //this instantiates a new object of your class
            nameOfYourClass newYourObject = new nameOfYourClass(//put any params you need here);
            txtNameOfYourTextBox.DataBindings.Add("Enabled", newLTDObjectBenInt, "YourTextBoxEnabled", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNameOfYourTextBox.DataBindings.Add("Value", newLTDObjectBenInt, "YourTextBoxEntered", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNameOfYourTextBox.DataBindings.Add("Visible", newLTDObjectBenInt, "YourTextBoxVisible", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public class nameOfYourClass
        {
            //constructor
            public nameOfYourClass(//same params here from the Load method)
            {
                //place any logic that you need here to load your class properly
                yourTextBoxVisible = true;
                yourTextBoxEnabled = true;
                yourTextBoxEntered = "this is the default text in my textbox";
            }
            private bool yourTextBoxEnabled;
            public bool YourTextBoxEnabled
            {
                get
                {
                    return yourTextBoxEnabled;
                }
                set
                {
                    yourTextBoxEnabled = value;
                }
            }
            private bool yourTextBoxVisible;
            public bool YourTextBoxVisible
            {
                get
                {
                    return yourTextBoxVisible;
                }
                set
                {
                    yourTextBoxVisible = value;
                }
            }
            private string yourTextBoxEntered;
            public string YourTextBoxEntered
            {
                get
                {
                    return yourTextBoxEntered;
                }
                set
                {
                    yourTextBoxEntered = value;
                }
            }
        }
