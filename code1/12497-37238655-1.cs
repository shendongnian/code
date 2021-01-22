    class Program
    {
        static void Main(string[] args)
        {
            //it's impossible to write Controller.IState p = new StateBase();
            //Controller.IState is hidden
            StateBase p = new StateBase();
            //p.Update(); //is not accessible
        }
    }
