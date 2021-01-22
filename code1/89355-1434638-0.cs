    class MyClass : IMyInterface
    {
        #region IMyInterface Members
        void IMyInterface.testmethod()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
