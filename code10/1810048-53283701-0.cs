        public List<WizardPage> wizPages
        {
            get
            {
                List<WizardPage> rtn = new List<WizardPage>();
                foreach (ViewModelBase vmb in Pages)
                {
                    rtn.Add(new WizardPage()
                    {   Title = vmb.DisplayName
                    ,   Description = vmb.DisplayDescription
                    ,   DataContext = vmb
                    });  //  rtn.Add
                }   //  foreach (ViewModelBase vmb in Pages)
                return rtn;
            }
        }
