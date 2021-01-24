    class ObjectImpl
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
        public void MethodB(ObjectB arg1, ObjectC arg2)
        {
            Console.WriteLine("Hi {0} and {1}", arg1, arg2);
        }
        public void MethodC(ObjectD arg1, ObjectE arg2)
        {
            Console.WriteLine("Bye {0} and {1}", arg1, arg2);
        }
    }
