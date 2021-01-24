    public abstract class A
    {
        protected abstract void WhateverFunction();
    }
    public abstract class B : A 
    {
        protected abstract override void WhateverFunction(); // HERE
    }
    public abstract class C : B
    {
        protected override void WhateverFunction()
        {
            //code here
        }
    }
