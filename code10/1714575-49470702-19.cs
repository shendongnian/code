    public class ListFragment :Fragment
    {
        private List<Products> _productList;
        private IListFragmentListener _listener;
        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            _listener = (IAddDateFragmentListner)context;
        }
        private void RandomFragmentMethod()
        {
            _productList = _listener.GetProductsList();
        }
    }
