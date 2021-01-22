    class B : A
    {
        public new void MethodToHide(object param)
        { 
            throw new DontUseThisMethodException();
        }
    
        protected void NewMethodInB()
        {}
    }
