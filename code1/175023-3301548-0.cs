    public static void MyMethod()
    {
        using (var scope = MyScopedBehavior.Begin())
        {
            //Do stuff with scope here
            scope.Complete(); // Tells the scope that it's good
        }
    }
