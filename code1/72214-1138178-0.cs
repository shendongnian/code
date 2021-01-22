    using (IObjectContainer db = Db4oFactory.OpenFile(dbfilename))
    {
    	var n = db.Ext().StoredClasses();
    	foreach (var x in n)
    	{
    		System.Diagnostics.Debug.WriteLine(x.GetName());
    	}
    	var c1 = db.Ext().StoredClass("OldNameSpace.OldType, OldAssembly");//
    	if (c1 != null)
    		c1.Rename("NewNameSpace.OldType, NewAssembly");
    
    	var c2 = db.Ext().StoredClass("System.Collections.Generic.List`1[[OldNameSpace.OldType, OldAssembly]], mscorlib");
    	if (c2 != null)
    		c2.Rename("System.Collections.Generic.List`1[[NewNameSpace.OldType, NewAssembly]], mscorlib");
    }
