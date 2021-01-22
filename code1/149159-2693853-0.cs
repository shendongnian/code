    public class BaseWebControl : System.Web.UI.WebControl
    {
        //base web control with application wide functionality built in
    }
    
    public abstract class BaseFormControl : BaseWebControl
    {
        //handles all 'common' form functionality
        //...
        //...
    
        //event handler for submit button calls abstract method submit form, 
        //which must be implemented by each inheriting class
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitForm();
        }
    
        protected abstract SubmitForm();
    }
    
    public class EmailFormControl : BaseFormControl
    {
        protected override SubmitForm()
        {
            //implement specific functionality to email form contents
    
        }
    }
    
    public class SecureFormControl : BaseFormControl
    {
        protected override SubmitForm()
        {
            //connect to WCF web service and submit contents
        }
    }
