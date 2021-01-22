    [StructLayout(LayoutKind.Sequential)]
    public struct MY_STRUCT
    {
       public uint aa;
       public uint ab;
       public uint ac;
    }
    
    MY_STRUCT pMS = new MY_STRUCT();
               
    FieldInfo[] fields = pMS.GetType().GetFields();
    foreach (var xInfo in fields)
       Console.WriteLine(xInfo.GetValue(pMS).ToString());
   
