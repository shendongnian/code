    void Main(string[] args)
    {
	 ClassA a = new ClassA();
	 System.Type[] types = new Type[(args.Length -1) / 2];
	 object[] ParamArray = new object[types.Length];
	 for (int i=0; i < types.Length; i++)
	 {
		  if(args[i*2 + 1].EndsWith("&"))
		{
			var type = System.Type.GetType(args[i*2 + 1].Substring(0,args[i*2 +1].Length - 1)); 
			ParamArray[i] = Convert.ChangeType(args[i*2 + 2],type);
			types[i] = System.Type.GetType(args[i*2 + 1]);
		}
		else
		{
	  		types[i] = System.Type.GetType(args[i*2 + 1]);
			ParamArray[i] = Convert.ChangeType(args[i*2 + 2],types[i]);
		}	   
	 }
	 MethodInfo callInfo = typeof(ClassA).GetMethod(args[0],types);
	 callInfo.Invoke(a, ParamArray);	
