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
                //Gte the control's text property and set it
            }
    
            #endregion
        }
    
        public class Form1Controller
        {
            public Form1Controller(ICustomerName theForm) //only sees ICustomerName methods
            {
                
                theForm.ShowName("Amazing Name");
            }
        }
