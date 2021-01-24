    class AAble : IAble
    {
        public virtual void f()
        {
            Debug.Log("---->> A - Able");
        }
    }
    class BAble : AAble, IAble
    {
        public override void f()
        {
            Console.WriteLine("---->> B - Able");
        }
    }
