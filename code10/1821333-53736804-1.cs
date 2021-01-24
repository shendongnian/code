    public static string getJsonFromClass(object objectName){
        return JsonConvert.SerializeObject(object);
    }
    
    public static T getObjectFromJson<T>(string jsonString){
        T t = default(T);
        try{
           t = JsonConvert.DeSerializeObject<T>(classname);
        }catch(Exception e){
           Debug.WriteLine(e.Message);
        }
        return t;
    }
