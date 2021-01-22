    public class SomeViewModel
    {
        public int SomeProperty
        {
            get
            { 
                return Properties.Settings.Default.SomeProperty; 
            }
            set
            { 
                Properties.Settings.Default.SomeProperty = value; 
            }
        }
    }
