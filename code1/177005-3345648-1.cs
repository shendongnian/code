    class CheckingAccount : Account
    {
        CheckAuthorizationScheme checkAuthorizationScheme;
    
        public override Account DeepClone()
        {
            CheckingAccount clone = new CheckingAccount();
            DeepCloneFields(clone);
            return clone;
        }
    
        protected override void DeepCloneFields(CheckingAccount clone)
        {
            base.DeepCloneFields(clone);
    
            clone.checkAuthorizationScheme = this.checkAuthorizationScheme.DeepClone();
        }
    }
