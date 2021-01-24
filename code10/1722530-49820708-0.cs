    public class VendorProxy : ReactiveObject
    {
    	// INPC for Name and other properties. 
    
    	public bool IsPrimary => _isPrimary.Value;
    	private readonly ObservableAsPropertyHelper<bool> _isPrimary;
    
    	public ReactiveCommand<Unit, Unit> MakePrimary => ReactiveCommand.Create(() => Unit.Default, 
    		canExecute: this.WhenAnyValue(x => x.IsPrimary, alreadyPrimary => !alreadyPrimary));
    
    	public VendorProxy(VendorDto dto, IObservable<VendorProxy> primaryVendors)
    	{
    		primaryVendors
    			.DistinctUntilChanged()
    			.Select(x => x == this)
    			.ToProperty(this, x => x.IsPrimary, out _isPrimary);
    			
    		if(dto.IsPrimary)
    			MakePrimary.Execute();
    	}
    
    	// implements IEquality.
    }
    
    public class ItemProxy : ReactiveObject
    {
    	public ReactiveList<VendorProxy> Vendors { get; }
    
    	public VendorProxy PrimaryVendor => _primaryVendor.Value;
    	private readonly ObservableAsPropertyHelper<VendorProxy> _primaryVendor;
    
    	public ItemProxy()
    	{
    		// these come from a web service.
    		var dtos = new[] {
    			new VendorDto {Name = "Vendor A", IsPrimary = true},
    			new VendorDto {Name = "Vendor B", IsPrimary = false}
    		};
    
    		Vendors = new ReactiveList<VendorProxy>();
    
    		var primaryStream = Vendors.ItemsAdded.Select(_ => Unit.Default)
    			.Merge(Vendors.ItemsRemoved.Select(_ => Unit.Default))
    			.Select(_ => Observable.Merge(Vendors.Select(v => v.MakePrimary.Select(__ => v))))
    			.Switch();
    
    		primaryStream
    			.DistinctUntilChanged()
    			.ToProperty(this, x => x.PrimaryVendor, out _primaryVendor);
    
    		var proxies = dtos
    			.Select(dto => new VendorProxy(dto, primaryStream));
    		
    		Vendors.AddRange(proxies);
    		
    		// some other subscriptions that require the primary vendor to do their work. 
    	}
    }
