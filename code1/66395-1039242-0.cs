    static class GridExtMethods
        {
            public static void SortAsICommand(this MyGrid grid)
            {
                //grid.Prop = value; possible
                grid.Sort += MyCustomSort;
            }
            static void MyCustomSort(object sender, SortEventArgs evtArgs)
            {
                Console.WriteLine("Sort {0} and {1}", evtArgs.First, evtArgs.Second);
            }
        }
....
    
    static void Main()
    {
       var grid = new MyGrid(10,20);
       grid.SortAsICommand();
       
       //grid.RaiseEvent(); do something that raises the event
    }
