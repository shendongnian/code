    public class ShoppingCart
    {
    	public IList<Stamp> Stamps { get; }
    	public IList<Letter> Letters { get; }
    	public IList<Parcel> Parcels { get; }
    	
    	public IEnumerable<IProduct> Products
    	{
    		get
    		{
    			return this.Stamps.Cast<IProduct>()
    				.Concat(this.Letters.Cast<IProduct>())
    				.Concat(this.Parcels.Cast<IProduct>());
    		}
    	}
    }
