    public class TMRequestContext : IExtension<OperationContext>  {
    
    	private OperationContext _Owner;
    
            public void Attach(OperationContext owner) {
                _Owner = owner;
            }
    
    	 public void Detach(OperationContext owner) {
                _Owner = null;
            }
    
    	public static TMRequestContext Current {
                get {
                    if (OperationContext.Current != null) {
                        return OperationContext.Current.Extensions.Find<TMRequestContext>();
                    } else {
                        return null;
                    }
                }
            }
    }
