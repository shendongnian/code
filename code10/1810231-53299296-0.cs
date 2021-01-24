        public void RunStarted(object automationObject,
        Dictionary<string, string> replacementsDictionary,
        WizardRunKind runKind, object[] customParams)
    {
        if (runKind.HasFlag(WizardRunKind.AsNewItem))
        {
            inputForm = new MyProjectModulo();
            inputForm.ShowDialog();
        }
