    public static Dictionary<double, Point3D[]> ComputeTimeSeries(Dictionary<double,    double> timeStep, Point3D[] dofs)
    {
       var timeSeries = new Dictionary<double, Point3D[]>();
       foreach(var keyValue in timeStep)
       {
          var tempArray = new Point3D[dofs.Length];
          for (int index=0; index < dofs.Length; index++)
              tempArray[index] = dofs[index] * keyValue.Value;
          timeSeries.Add(keyValue.Key, tempArray);  
       }
       return timeSeries;
    }
