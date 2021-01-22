    public abstract class ExcelRowBase
        {
            public object[,] data;
            public ExcelRowBase(int index)
            {
                data = new object[2, index + 1];
            }
        }
     public class InstanceRowModel : ExcelRowBase 
        {
            public InstanceRowModel() : base(8) 
            { 
            //constructor unique to Wire Table 
            }
            public object Configuration
            {
                get
                {
                    return data[1, 1];
                }
                set
                {
                    data[1, 1] = value;
                }
            }
    ...
