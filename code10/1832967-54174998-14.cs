csharp
// typename : the Animal.Type property
// ns : the namespace string 
private Type ResolveAnimalType(string typename,string ns){
    if(string.IsNullOrEmpty(ns)){ ns = "App.Models";}
    typename= $"{ns}.{typename}";
    var type=Type.GetType(
        typename,
        assemblyResolver:null,  // if you would like load from other assembly, custom this resovler
        typeResolver: (a,t,ignore)=> a == null ? 
            Type.GetType(t, false, ignore) : 
            a.GetType(t, false, ignore),
        throwOnError:true,
        ignoreCase:false
    );
    return type;
}
Anyway, **you could custom the way we resolve the target `Type` according to your own needs**. And then **cast the json object to your wanted `Type` by method `ToObject<T>()`**:
csharp
[HttpPost]
public IActionResult Post([FromBody] JObject json)
{
    var typename = json.Value<string>("type");
    if(String.IsNullOrEmpty(typename)) 
        ModelState.AddModelError("json","any animal must provide a `type` property");
    
    // resolve the target type
    var t= ResolveAnimalType(typename,null);
    // get the method of `.ToObject<T>()`
    MethodInfo mi= typeof(JObject)
        .GetMethods(BindingFlags.Public|BindingFlags.Instance)
        .Where(m=> m.Name=="ToObject" && m.GetParameters().Length==0 && m.IsGenericMethod  )
        .FirstOrDefault()
        ?.MakeGenericMethod(t); // ToObject<UnknownAnimialType>()
    var animal = mi?.Invoke(json,null);
    return new JsonResult(animal); 
}
