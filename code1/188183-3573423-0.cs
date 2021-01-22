        private List<Control> m_lstControlsToValidate;
        private void SetupControlsToValidate()
        {
            m_lstControlsToValidate = new List<Control>();
            
            //Add data entry controls to be validated
            m_lstControlsToValidate.Add(sometextbox);
            m_lstControlsToValidate.Add(sometextbox2);
        }
       private void ValidateSomeTextBox()
       {
            //Call this method in validating event.
            //Validate and set error using error provider
       }
       
       Private void Save()
       {
            foreach(Control thisControl in m_lstControlsToValidate)
            {
                if(!string.IsNullOrEmpty(ErrorProvider.GetError(thisControl)))
                {                    
                    //Do not save, show messagebox.
                    return;
                }
            }
         //Continue save
       }
