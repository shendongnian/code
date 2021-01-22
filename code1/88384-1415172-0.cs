    public class MyEnum
    {
    
    public static readonly MyEnum Enum1=new MyEnum("This will work",1);
    public static readonly MyEnum Enum2=new MyEnum("This.will.work.either",2);
    public static readonly MyEnum[] All=new []{Enum1,Enum2};
    private MyEnum(string name,int value)
    {
    Name=name;
    Value=value;
    }
    
    public string Name{get;set;}
    public int Value{get;set;}
    
    public override string ToString()
    {
    return Name;
    
    }
    }
