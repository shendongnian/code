    namespace Project
    {
        public class BusinessLayer
        {
            public IList<Product> GetProducts()
            {
                return new Select().From( Products.Schema ).Where( Products.Columns.Status ).IsEqualTo( true ).ExecuteTypedList<Product>();
            }
        }
    }
