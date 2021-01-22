        public  Parent.FillName obj;
        public PopUp(Parent.FillName objTMP)//parameter as deligate type
        {
            obj = objTMP;
            InitializeComponent();
 
        }
 
       private void OKButton_Click(object sender, RoutedEventArgs e)
        {
          
          
            obj(txtFirstName.Text); 
            // Getname() function will call automatically here
            this.DialogResult = true;
        }
