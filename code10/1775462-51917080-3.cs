        public partial class ThisAddIn
        {
            private AddInUtilities utilities;
    
            protected override object RequestComAddInAutomationService()
            {
                if (utilities == null)
                    utilities = new AddInUtilities();
    
                return utilities;
            }
      ....
