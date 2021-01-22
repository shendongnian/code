    using Sample.Extensions;
    namespace Sample
    {
        class Program
        {
            static void Main (string[] args)
            {
                byte[] buffer = new byte[] { 00, 01, 02 };
                byte[] header = new byte[] { 00, 01 };
                // old way, buffer will still contain { 00, 01, 02 }
                buffer.RemoveHeader (header);
                // new way! as a function, we obtain new array of { 02 }
                byte[] stripped = buffer.RemoveHeaderFunction (header);
            }
        }
    }
