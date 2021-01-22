    public static Dictionary<double, List<Point3D>> ComputeTimeSeries(Dictionary<double, double> timeStep, List<Point3D> dofs)
    {
       var timeSeries = new Dictionary<double, List<Point3D>>();
       foreach(var keyValue in timeStep)
       {
          List<double> lst = new List<double>();
          foreach (Point3D point in dofs)
             lst.Add(point* keyValue.Value);
    
          timeSeries.Add(keyValue.Key, lst);  // the point3d*double operation is already being overloaded.
       }
       return timeSeries;
    }
