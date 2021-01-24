    // use HDFql namespace (make sure it can be found by the C# compiler)
    using AS.HDFql;
    public class Test
    {
        public static void Main(string []args)
        {
            // declare variables
            double [,]data = new double[3, 3];
            int x;
            int y;
            // use (i.e. open) HDF file "test.h5"
            HDFql.Execute("USE FILE test.h5");
            // register variable "data" for subsequent use (by HDFql)
            HDFql.VariableRegister(data);
            // select (i.e. read) dataset "dset" into variable "data"
            HDFql.Execute("SELECT FROM dset INTO MEMORY " + HDFql.VariableGetNumber(data));
            // unregister variable "data" as it is no longer used/needed (by HDFql)
            HDFql.VariableUnregister(data);
            // display content of variable "data"
            for(x = 0; x < 3; x++)
            {
                for(y = 0; y < 3; y++)
                {
                    System.Console.WriteLine(data[x, y]);
                }
            }
        }
    }
