    using System.Linq;
    ...
    
    public static int[] Distinct(int[] handles)
    {
        return handles.ToList().Distinct().ToArray();
    }
