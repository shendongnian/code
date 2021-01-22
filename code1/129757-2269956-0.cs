private static String GetInterfaceGuid(Type type) 
{ 
    string sGuid = string.Empty;
    try{
        Object[] attributes = type.GetCustomAttributes(typeof(GuidAttribute), true); 
        if (attributes != null && attributes.Length >= 1){
           sGuid = String.Format("{{{0}}}", ((GuidAttribute)attributes[0]).Value); 
        }else{
           // FAIL!
        }
    }catch(System.Exception up){
        throw up;
    }
    return sGuid;
} 
