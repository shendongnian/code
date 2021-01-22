    private HttpContext context;
    
    public MyItemEventReceiver() {
    	context = HttpContext.Current;
    }
    
    public override void ItemAdding(SPItemEventProperties properties) {
    	HttpFileCollection collection = context.Request.Files;
    	foreach (String name in collection.Keys) {
    		if (collection[name].ContentLength > 0) {
    			// Do what you need with collection[name].InputStream
    		}
    	}
    }
