    namespace ParentChild
    {
       // Parent Form Class
        public partial class ParentForm : Form
        {
            // Forms Objects
            ChildForm child_obj = new ChildForm();
    
    
            // Show Child Forrm
            private void ShowChildForm_Click(object sender, EventArgs e)
            {
                child_obj.ShowDialog();
            }
    
           // Read Data from Child Form 
            private void ReadChildFormData_Click(object sender, EventArgs e)
            {
                int ChildData = child_obj.child_value;  // it will have 12345
            }
    
       }  // parent form class end point
    
    
       // Child Form Class
        public partial class ChildForm : Form
        {
    
            public int child_value = 0;   //  variable where we will store value to be read by parent form  
         
            // save something into child_value  variable and close child form 
            private void SaveData_Click(object sender, EventArgs e)
            {
                child_value = 12345;   // save 12345 value to variable
                this.Close();  // close child form
            }
    
       }  // child form class end point
      
    
    }  // name space end point
