    class Factory<TProduct> where TProduct : new()
	{
		public delegate void ProductInitializationMethod(TProduct newProduct);
		private ProductInitializationMethod m_ProductInitializationMethod;
		public Factory(ProductInitializationMethod p_ProductInitializationMethod)
		{
			m_ProductInitializationMethod = p_ProductInitializationMethod;
		}
		
		public TProduct CreateProduct()
		{
			var prod = new TProduct();
			m_ProductInitializationMethod(prod);
			return prod;
		}
	}
	
	class ProductA
	{
		public static void InitializeProduct(ProductA newProduct)
		{
			// .. Do something with a new ProductA
		}
	}
	class ProductB
	{
		public static void InitializeProduct(ProductB newProduct)
		{
			// .. Do something with a new ProductA
		}
	}
	
	class GenericAndDelegateTest
	{
		public static void Main()
		{
			var factoryA = new Factory<ProductA>(ProductA.InitializeProduct);
			var factoryB = new Factory<ProductB>(ProductB.InitializeProduct);
			ProductA prodA = factoryA.CreateProduct();
			ProductB prodB = factoryB.CreateProduct();
		}
	}
