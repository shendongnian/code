 c#
public readonly struct SomeStruct
{
    public SomeStruct(string stringProperty, int intProperty)
    {
        this.StringProperty = stringProperty;
        this.IntProperty = intProperty;
    }
    public string StringProperty { get; }
    public int IntProperty { get; }
}
