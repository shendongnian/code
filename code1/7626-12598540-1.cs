    private class ExtendedClass //: BaseClass - like to inherit but can't
    {
        public readonly BaseClass bc = null;
        public ExtendedClass(BaseClass b)
        {
            this.bc = b;
        }
        public int ExtendedProperty
        {
            get
            {
            }
        }
    }
