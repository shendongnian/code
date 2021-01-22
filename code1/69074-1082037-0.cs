    public interface IComboBoxFiller {
        void Fill( ComboBox cbo );
    }
    
    public class UsersComboBoxFiller : IComboBoxFiller {
        public bool OnlyOnlineUsers {get;set;}
    
        public void Fill( ComboBox cbo ) {
            // there is logic for combobox filling
            // you can dynamicly generate where condition
            // by the "OnlyOnlineUsers"
        }
    }
