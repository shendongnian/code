    public class SomeQuoteProcessor1 : CompositeQuoteProcessor
    {
        public SomeQuoteProcessor1(Service1 service1, Service3 service3) :
            base(service1, service3)
        {
        }
    }
