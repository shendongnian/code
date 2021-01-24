        public interface IConsumer
        {
            void Consume(Product product);
    
            ICommonObject Visit(IProductVisitor productVisitor);
        }
    
        public class ConcreteConsumerA : IConsumer
        {
            public void Consume(Product product)
            {
                /* The logic that needs for ParamA of SpecificProductA is now  
     pushed into the Visitor. */
                var productAVisitor = new SpecificProductAVisitor();
                ICommonInterface commonInterfaceWithParamA = product.GetCommonInterface(productAVisitor); 
            }
        }
    
        public class ConcreteConsumerB : IConsumer
        {
            public void Consume(Product product)
            {
            /* The logic that needs for ParamB of SpecificProductB is now  
     pushed into the Visitor. */
                var productBVisitor = new SpecificProductBVisitor();
                ICommonInterface commonInterfaceWithParamB = product.GetCommonInterface(productBVisitor); 
            }
        }
