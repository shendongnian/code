    class MyClass
    {
        public MyClass()
        {
            IsTrue = true;
            IsFalse = false;
        }
        public bool IsTrue { get; set; }
    
        public bool IsFalse { get; set; }
        [...]
        public void Something()
        {
            var isTrue = this.IsTrue;
            var isFalse = this.IsFalse;
        }
}
