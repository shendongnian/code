    class TypeABusinessLogic : ITypeABusinessLogic
    {
        public virtual void DoBusinessLogic()
        {
            Console.WriteLine("Do Business Logic for Type A");
        }
    }
    
    class TypeBBusinessLogic : ITypeBBusinessLogic
    {
        public virtual void DoBusinessLogic()
        {
            Console.WriteLine("Do Business Logic for Type B");
        }
    }
    class TypeAApplicationLogic : ITypeAApplicationLogic
    {
        public void DoApplicationLogic()
        {
            Console.WriteLine("Do Application Logic for Type A");
        }
    }
    class TypeBApplicationLogic : ITypeBApplicationLogic
    {
        public void DoApplicationLogic()
        {
            Console.WriteLine("Do Application Logic for Type B");
        }
    }
