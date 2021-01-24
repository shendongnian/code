        // Initialize 'myPanel'
        public PXFilter<PX.Objects.CR.Contact> myPanel;
        
        // Make the 'Letters' menu available to 'Automation Steps'
        public PXAction<PX.Objects.CR.Contact> letters;
        [PXUIField(DisplayName = "Letters", MapEnableRights = PXCacheRights.Select)]
        [PXButton(SpecialType = PXSpecialButtonType.Report)]
        protected virtual IEnumerable Letters(PXAdapter adapter, string reportID)
        {
            // Launch the PXSmartPanel dialog and test result
            if (myPanel.AskExt(true) == WebDialogResult.OK)
            {
                PXReportRequiredException ex = null;
                Contact contact = Base.Caches[typeof(Contact)].Current as Contact;
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                //*** Get the extended class
                var myExt = myPanel.Current.GetExtension<ContactExt>();
                parameters["ContactID"] = contact.ContactID.ToString();
                //*** Get the extended class's custom field value
                parameters["SSN"] = myExt.UsrSSN;
            
                throw new PXReportRequiredException(parameters, reportID, "");
                if (ex != null) throw ex;
            }
            return adapter.Get();        
        }
