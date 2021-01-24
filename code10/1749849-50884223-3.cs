    using System;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    
    namespace ClassLibrary1
    {
        public class WorkerProducer
        {
            public async Task ProduceWorker()
            {
                //await ProductTransformer_Transformer.SendAsync(new Worker())
            }
        }
    
        public class ProductTransformer
        {
            public IObservable<Product> Products { get; private set; }
            public TransformBlock<Worker, Product> Transformer { get; private set; }
            
            private Task<Product> CreateProductAsync(Worker worker) => Task.FromResult(new Product());
    
            public ProductTransformer()
            {
                Transformer = new TransformBlock<Worker, Product>(wrk => CreateProductAsync(wrk));
                Products = Transformer.AsObservable();
            }
        }
    
        public class ProductConsumer
        {
            private ThirdParty ThirdParty { get; set; } = new ThirdParty();
            private ProductTransformer Transformer { get; set; }
    
            public ProductConsumer()
            {
                ThirdParty.CheckProducts(Transformer.Products.ToEnumerable());
                {
                }
            }
    
        public class Worker { }
        public class Product { }
    
        public class ThirdParty
        {
            public void CheckProducts(IEnumerable<Product> products)
            {
            }
        }
    }
