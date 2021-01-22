    class A
    {
        protected void MethodToExpose()
        {}
    
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        protected void MethodToHide(object param)
        {}
    }
