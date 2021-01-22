        public class FormTest:Form
        {
        public delegate int validateLogin(string userID,string Password);
        public validateLogin validate;
        public event validateLogin validateEvent;
        public void submitWithcallback()
        {
            string userId=string.Empty,pwd=string.Empty;
            validate(userId, pwd);            
        }
        public void submitWithFuncDelegate(Func<string,string,int> funcDelegate)
        {
            string userId = string.Empty, pwd = string.Empty;
            funcDelegate(userId, pwd);           
        }
        public void submitWithEvent()
        {
            string userId = string.Empty, pwd = string.Empty;
            validateEvent(userId, pwd);
        }
        }
