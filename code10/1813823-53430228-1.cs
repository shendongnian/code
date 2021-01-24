    public class ProductDialogViewModel : Notifier
    {
    	public ProductDialogViewModel() { }
    	private MyProduct _product = null;
    	public MyProduct Product
    	{
    		get { return _product; }
    		set
    		{
    			if (_product!=null)
    			{
    				_product.PropertyChanged -= Product_PropertyChanged;
    			}
    			_product = value;
    			if (_product != null)
    			{
    				_product.PropertyChanged += Product_PropertyChanged;
    			}
    		}
    	}
    	private void Product_PropertyChanged(object sender, PropertyChangedEventArgs e)
    	{
    		if (e.PropertyName==nameof(MyProduct.HasError))
    		{
    			OnPropertyChanged(nameof(HasError));
    		}
    	}
    	public bool HasError => Product.HasError;
    }
