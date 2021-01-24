    public class ReferenceCountedSingleton : AbstractLifestyleManager, IContextLifestyleManager
    {
    	private readonly object _lock = new object();
    	private Burden _cachedBurden;
    	private int _referenceCount;
    
    	public override void Dispose()
    	{
    		var localInstance = _cachedBurden;
    		if (localInstance != null)
    		{
    			localInstance.Release();
    			_cachedBurden = null;
    		}
    	}
    
    	public override object Resolve(CreationContext context, IReleasePolicy releasePolicy)
    	{
    		lock(_lock)
    		{
    			_referenceCount++;
    
    			if (_cachedBurden != null)
    			{
    				Debug.Assert(_referenceCount > 0);
    				return _cachedBurden.Instance;
    			}
    
    			if (_cachedBurden != null)
    			{
    				return _cachedBurden.Instance;
    			}
    			var burden = CreateInstance(context, false);
    			_cachedBurden = burden;
    			Track(burden, releasePolicy);
    			return burden.Instance;
    		}
    	}
    
    	public override bool Release(object instance)
    	{
    		lock (_lock)
    		{
    			if (_referenceCount > 0) _referenceCount--;
    			if (_referenceCount > 0) return false;
    			_referenceCount = 0;
    			_cachedBurden = null;
    			return base.Release(instance);
    		}
    	}
    
    	protected override void Track(Burden burden, IReleasePolicy releasePolicy)
    	{
    		burden.RequiresDecommission = true;
    		base.Track(burden, releasePolicy);
    	}
    
    	public object GetContextInstance(CreationContext context)
    	{
    		return context.GetContextualProperty(ComponentActivator);
    	}
    }
