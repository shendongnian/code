public class ObjectEntry
{
    public object objRef;
    public string desc;
    
    public ObjectEntry(object objectReference)
    {
        objRef = objectReference;
        if (objRef = null) {desc = "Nothing";}
        else {desc = objRef.Description;} //or whatever info you can get from a proper objRef value
    }
}
newObj = new ObjectEntry(null);
dict.add(newObj, newObj.desc);
