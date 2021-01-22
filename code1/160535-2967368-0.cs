    using MathWorks.MATLAB.NET.Arrays;
    using MathWorks.MATLAB.NET.Utility;
    using MyMatlabComponent;
    // ...
    // Inside the appropriate method
    List<double> l = new List<double>();
    MyMatlabComponentclass c = new MyMatlabComponentclass();
    MWNumericArray m = c.GenerateSomeNumbers();
    l.Add((double)m);
    
