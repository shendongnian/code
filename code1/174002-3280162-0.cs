    public static Dictionary<double, IEnumerable<Point3D>> ComputeTimeSeries(Dictionary<double, double> timeStep, List<Point3D> dofs)
    {
       var timeSeries = new Dictionary<double, List<Point3D>>();  
       foreach(var keyValue in timeStep)    
       {
          // the point3d*double operation is already being overloaded.
          timeSeries.Add(keyValue.Key, dofs.Select(pt=>pt*keyValue.Value));  
       } 
       return timeSeries; 
    }
