    public class NvApplicationContext : ApplicationContext {
        public static readonly NvApplicationContext Current = new NvApplicationContext();
        public void RegisterForm(Form frm) {
            // register event handler on form here
        }
    }
