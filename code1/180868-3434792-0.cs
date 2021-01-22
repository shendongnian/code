    public class User {
        public event EventHandler UserNameChanged;
        
        private string m_Name;
        public string Name {
            get { return m_Name; }
            set {
                if(m_Name != value) {
                    m_Name = value;
                    // assuming single-threaded application
                    if(UserNameChanged != null)
                        UserNameChanged(this, EventArgs.Empty);
                }
            }
        }
        // everything else is the same...
    }
