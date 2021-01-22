    private IList<OrdersResult> _bindingSource;
    
            public IList<OrdersResult> BindingSource
            {
                get
                {
                    //_bindingSource = OrderDataControl.Instance.GetAll();
                    _bindingSource = 
                        OrderDataControl.Instance.GetSimpleOrderList(_firstResult, _maxResult);
                    return _bindingSource;
                }
    
                set
                {
                    _bindingSource = value;
                }
            }
