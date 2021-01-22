    class ClassA
    {
        public event EventHandler Test;
        ~ClassA()
        {
            Console.WriteLine("A being collected");
        }
    }
    class ClassB
    {
        public ClassB(ClassA instance)
        {
            instance.Test += new EventHandler(instance_Test);
        }
    
        ~ClassB()
        {
            Console.WriteLine("B being collected");
        }
    
        void instance_Test(object sender, EventArgs e)
        {
            // this space is intentionally left blank
        }
    }
