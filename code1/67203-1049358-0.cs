    class BusinessObjectBase
    {
        public void Add(string newAccount)
        {
            if(_isNew && _id>0) throw new InvalidOperationException("Invalid precondition state");
            AddOperation(newAccount);
            if (!_isNew && _id == 0) throw new InvalidOperationException("Invalid post condition state");
        }
        protected void virtual AddOperation(string newAccount)
        {
            // Code from base AddOperation
        }
    }
    class BusinessObject : BusinessObjectBase {
        protected override void AddOperation(string newAccount)
        {
            //custom AddOperation
        }
    }
