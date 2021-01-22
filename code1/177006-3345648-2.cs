    class CheckingAccount : Account
    {
        CheckAuthorizationScheme checkAuthorizationScheme;
    
        public override Account DeepClone()
        {
            CheckingAccount clone = new CheckingAccount();
            DeepCloneFields(clone);
            return clone;
        }
    
        protected override void DeepCloneFields(Account clone)
        {
            base.DeepCloneFields(clone);
            
            ((CheckingAccount)clone).checkAuthorizationScheme = this.checkAuthorizationScheme.DeepClone();
        }
    }
