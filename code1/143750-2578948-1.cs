    using Sample.Extensions;
    namespace Sample
    {
        class Program
        {
            static void Main (string[] args)
            {
                byte[] buffer = new byte[] { 00, 01, 02 };
                byte[] header = new byte[] { 00, 01 };
                buffer.RemoveHeader (header);
                // hm, so everything compiles and runs, but buffer == { 00, 01, 02 }
            }
        }
    }
