    namespace StackOverFlowSample
    {
        abstract class BusinessObjectBase
        {
            private bool _isNew;
            private int _id;
    
            protected abstract void AddInternal(string newAccount);
            public void Add(string newAccount)
            {
                if(_isNew && _id>0) throw new InvalidOperationException("Invalid precondition state");
                AddInternal(newAccount);    
                if (!_isNew && _id == 0) throw new InvalidOperationException("Invalid post condition state");
            }
        }
        class BusinessObject : BusinessObjectBase {
            protected override void AddInternal(string newAccount)
            {
                //Save newAccount to database
            }
        }
    }
