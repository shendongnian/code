    public interface IMyStructModifier
    {
        String Name { set; }
    }
    public struct MyStruct : IMyStructModifier ...
    
    List<Object> obList = new List<object>();
    obList.Add(new MyStruct("ABC"));
    obList.Add(new MyStruct("DEF"));
    
    MyStruct temp = (MyStruct)obList[1];
    temp.Name = "Gishu";
    foreach (MyStruct s in obList) // => "ABC", "DEF"
    {
        Console.WriteLine(s.Name);
    }
    IMyStructModifier temp2 = obList[1] as IMyStructModifier;
    temp2.Name = "Now Gishu";
    foreach (MyStruct s in obList) // => "ABC", "Now Gishu"
    {
        Console.WriteLine(s.Name);
    }
