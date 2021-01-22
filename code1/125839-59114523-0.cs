csharp
public class FooSettings
{
    public bool Prop1 { get; set; }
    public bool Prop2 { get; set; }
    
    public TimeSpan Prop3 { get; set; }
    
    public FooSettings()
    {
        this.Prop1 = false;
        this.Prop2 = false;
        this.Prop3 = new TimeSpan().ExtensionMethod(CustomEnum.Never);
    }
    
    public FooSettings BoolSettings
    (bool incomingFileCacheSetting, bool incomingRuntimeCacheSetting)
    {
        this.Prop1 = incomingFileCacheSetting;
        this.Prop2 = incomingRuntimeCacheSetting;
        return this;
    }
    
    public FooSettings Prop3Setting
    (TimeSpan incomingCustomInterval)
    {
        this.Prop3 = incomingCustomInterval;
        return this;
    }
    
    public FooSettings Prop3Setting
    (CustomEnum incomingPresetInterval)
    {
        return this.Prop3Setting(new TimeSpan().ExtensionMethod(CustomEnum.incomingPresetInterval));
    }
}
    
public class Foo
{
    public bool Prop1 { get; private set; }
    public bool Prop2 { get; private set; }
    
    public TimeSpan Prop3 { get; private set; }
    
    public CallTracker
    (
        FooSettings incomingSettings
    )
    {
        // implement conditional logic that handles incomingSettings
    }
}
could then be consumed as:
csharp
FooSettings newFooSettings = new FooSettings {Prop1 = false, Prop2 = true}
newFooSettings.Prop3Setting(new TimeSpan(3,0,0));
Foo newFoo = new Foo(newFooSettings)
or
csharp
FooSettings newFooSettings = new FooSettings()
    .BoolSettings(false, true)
    .Prop3Setting(CustomEnum.Never)
Foo newFoo = new Foo(newFooSettings)
obviously a bit overkill for a simple class, but it gives alot of control over the types of data that can be funneled down to a single property, IE: TimeSpan can be parsed from a custom enum type using an extension method
