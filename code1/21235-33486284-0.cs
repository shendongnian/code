    namespace Core.Text.Menus
    {
        public abstract class AbstractBaseClass
        {
            public string SELECT_MODEL;
            public string BROWSE_RECORDS;
            public string SETUP;
        }
    }
     
    namespace Core.Text.Menus
    {
        public class English : AbstractBaseClass
        {
            public English()
            {
                base.SELECT_MODEL = "Select Model";
                base.BROWSE_RECORDS = "Browse Measurements";
                base.SETUP = "Setup Instrument";
            }
        }
    }
