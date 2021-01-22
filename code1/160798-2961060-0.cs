        private TextBox UserName
        {
            get
            {
                return GetWizardControl<TextBox>("UserName");
            }
        }
        private TextBox Email
        {
            get
            {
                return GetWizardControl<TextBox>("Email");
            }
        }
        private T GetWizardControl<T>(string id) where T : Control
        {
            return (T)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl(id);
        }
