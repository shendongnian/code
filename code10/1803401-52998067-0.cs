    void Main()
    {
    	var t = typeof(AmStaticHearMeRoar);
    	TryIt(t,RunConstructor);
    	TryIt(t,RunTypeInitializer);
    	TryIt(t, RunClassConstructor);
    }
    
    static void TryIt(Type t, Action<Type> f){
    	Console.WriteLine("value is:" + AmStaticHearMeRoar.State);
    	AmStaticHearMeRoar.Reset();
    	try{
    		f(t);
    		Console.WriteLine("constructor rerun, value is:" + AmStaticHearMeRoar.State);
    	} catch(Exception ex){
    		ex.Dump();
    		Console.WriteLine("constructor rerun?, value is:" + AmStaticHearMeRoar.State);
    	}
    	finally{
    		AmStaticHearMeRoar.Reset();
    	}
    	
    }
    
    static void RunConstructor(Type t) {
    	var m = t.GetConstructor(BindingFlags.Static | BindingFlags.NonPublic, System.Type.DefaultBinder, System.Type.EmptyTypes, null);
    	m.Dump();
    	m.Invoke(new object[] {});
    }
    static void RunTypeInitializer(Type t){
    	t.TypeInitializer.Invoke(BindingFlags.NonPublic | BindingFlags.Static, System.Type.DefaultBinder, new object[] {},System.Globalization.CultureInfo.DefaultThreadCurrentCulture);
    }
    static void RunClassConstructor(Type t) {
    	// only works if it hasn't been run =(
    	RuntimeHelpers.RunClassConstructor(t.TypeHandle);
    }
    // Define other methods and classes here
    
    public static class AmStaticHearMeRoar
    {
    	static int myStaticState;
    	static AmStaticHearMeRoar()
    	{
    		myStaticState = 3;
    	}
    	public static void Reset() {
    		myStaticState = 0;
    	}
    	public static int State => myStaticState;
    }
