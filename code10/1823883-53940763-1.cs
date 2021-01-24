     public class ServiceTest : Test
    {
        public double add(double a, double b)
        {
             // get the property through IncomingMessageProperties property
            Guid gu = (Guid)OperationContext.Current.IncomingMessageProperties["myGuid"];
            Console.WriteLine(gu);
            return a + b;
        }
    }
