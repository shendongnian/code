    class ObjectImpl
    {
        // Everything works as before except broken build
        public void MethodA(ObjectA arg1)
        {
            if (arg1.Something)
            {
                Console.WriteLine("Hi {0} and {1}", new ObjectB(arg1), new ObjectC(arg1));
            }
            else
            {
                Console.WriteLine("Bye {0} and {1}", new ObjectD(arg1), new ObjectE(arg1));
            }
        }
    }
