    class test
    {
        public bool Validate()
        {
            return new ValidatorCollection(
                FailAction,
                SuccessAction)
            {
                valTrue,
                valTrue,
                valFalse
            }.Validate();
        }
        public void FailAction()
        {
            LogLogic.AddEntry(LogLogic.GetEnumDescription(LogMessages.StatusMessages.JobValidationFailed));
        }
        public void SuccessAction()
        {
            LogLogic.AddEntry(LogLogic.GetEnumDescription(LogMessages.StatusMessages.JobValidationPassed));
        }
        public bool valTrue()
        {
            return true;
        }
        public bool valFalse()
        {
            return false;
        }
    }
