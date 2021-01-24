    public class BaseForm : Form {
        public BaseForm() {
            NvApplicationContext.Current.RegisterForm(this);
        }
    }
