    public interface ICustomerName
        {
            void ShowName(string theName);
        }
    
        public partial class Form1 : Form, ICustomerName
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            #region ICustomerName Members
    
            public void ShowName(string theName)
            {
                //Gets all controls that show customer names and sets the Text propert  
                //totheName
            }
    
            #endregion
        }
    
        //developers program logic into this class 
        public class Form1Controller
        {
            public Form1Controller(ICustomerName theForm) //only sees ICustomerName methods
            {
                //Look, i can't even see the Form object from here
                theForm.ShowName("Amazing Name");
            }
        }
