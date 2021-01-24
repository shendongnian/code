    public class SubClass : SuperClass
    {
        public bool IsCallBaseClassMethod { get; set; }
        public override void Method(){
            if (IsCallBaseClassMethod)
            {
                base.Method();
            }
        }
    }
