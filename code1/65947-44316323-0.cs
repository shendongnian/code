    using System.Reflection; using System.Text.StringBuilder();
    public static T CopyClass2<T>(T obj){
	    T objcpy = (T)Activator.CreateInstance(typeof(T));
	    obj.GetType().GetProperties().ToList()
        .ForEach( p => objcpy.GetType().GetProperty(p.Name).SetValue(objcpy, p.GetValue(obj)));
	    return objcpy;
