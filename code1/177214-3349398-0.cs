    public class EditMapUtlities
    {
        //Omitting the wireup details for now
        private SessionHandler ApplicationState {get; set;}
    
        public static Boolean isInitialEditMapPageLoad
        {
            get { return ApplicationState.GetValue<Boolean>("EditMapInitialPageLoad"); }
            set { ApplicationState.SetValue("EditMapInitialPageLoad", value); }
        }
    
    // REST OF CLASS NOT GERMAIN TO DISCUSSION AND OMITTED
    }
