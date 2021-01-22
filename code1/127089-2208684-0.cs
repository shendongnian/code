    public interface IProductFactory<T> where T : class
    {
        T CreateProduct(string filename);
        T DeserializeInstance(string filename);
    }
    public abstract  class ProductFactoryBase<T> :  IProductFactory<T> where T : class
    {
        public abstract T CreateProduct(string filename);
        public T DeserializeInstance(string filename)
        {
            var myFormatter = new BinaryFormatter();
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                return myFormatter.Deserialize(stream) as T;
            }
        }
    }
    public class ProductV1Factory : ProductFactoryBase<ProductV1>
    {
        public override ProductV1 CreateProduct(string filename)
        {
            return DeserializeInstance(filename);
        }
    }
    public class ProductV2Factory : ProductFactoryBase<ProductV2>
    {
        ProductV1Factory successor = new ProductV1Factory();
        public override ProductV2 CreateProduct(string filename)
        {
            var product = DeserializeInstance(filename);
            if (product==null)
            {
                product = new ProductV2(successor.CreateProduct(filename));
            }
            return product;
        }
        
    }
    public class ProductV2
    {
        public ProductV2(ProductV1 product)
        {
            //construct from V1 information
        }
    }
    public class ProductV1  
    {
    }
