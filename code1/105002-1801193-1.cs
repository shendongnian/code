    class ApplicationData{
        private string _firstName;
        public string FirstName;
        {
           get { return _firstName;; }
           set { __firstName;=value; }
        }
    
        private string _lastName;
        public string LastName;
        {
           get { return _lastName; }
           set { __lastName=value; }
        }
    }
    
    class ChildForm : Form
    {
       private ApplicationData _applicationData=null;
    
       public ApplicationData AppData
       {
           get { return _applicationData; }
           set { _applicationData=value; }
       }
       void Load_Form(object sender, EventArgs args)
       {
             txtFirstName.Text=AppData.FirstName;
             txtLastName.Text=AppData.LastName;
        }
       void Form_Closing(object sender, EventArgs args)
       {
             AppData.FirstName=txtFirstName.Text;
             AppData.LastName=txtLastName.Text;
        }
    
    }
    
    class MainForm : Form
    {
        private ApplicationData _applicationData=new ApplicationData();
    
        void Button_Click(object sender, EventArgs args)
        {
            ChildForm childForm=new ChildForm ();
            ChildForm.AppData=_applicatonData;
            ChildForm.ShowDialog();
            string fullName=_applicatonData.LastName + " " + _applicatonData.FirstName
        }
    }
