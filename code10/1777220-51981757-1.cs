    // use HDFql namespace (make sure it can be found by the C# compiler)
    using AS.HDFql;
    public class Example
    {
        public static void Main(string []args)
        {
            // use (i.e. open) HDF file "my-file.h5"
            HDFql.Execute("USE FILE my-file.h5");
            // select (i.e. read) attribute "foo" and populate default cursor with its data
            HDFql.Execute("SELECT FROM foo");
            // display content of default cursor
            while(HDFql.CursorNext() == HDFql.Success)
            {
                System.Console.WriteLine(HDFql.CursorGetChar());
            }
        }
    }
