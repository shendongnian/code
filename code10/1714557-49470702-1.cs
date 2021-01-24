    public class ListFragment :Fragment
    {
        private List<Products> _productList;
        
        public static ListFragment NewInstance(List<Products> productList)
        {
            _productList = productList;
            ListFragment fragment = new ListFragment();
            return fragment;
        }
    }
