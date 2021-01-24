    public class ObjectImplementation : IObject
    {
        public void MethodA(ObjectA arg1)
        {
            if (arg1.Something)
            {
                MethodB(new ObjectB(arg1), new ObjectC(arg1));
            }
            else
            {
                MethodC(new ObjectD(arg1), new ObjectE(arg1));
            }
        }
        public virtual void MethodB(ObjectB arg1, ObjectC arg2)
        {
            
        }
        public virtual void MethodC(ObjectD arg1, ObjectE arg2)
        {
            
        }
    }
