    // create custom dictionary inherited formatter.
    public class EventFormatter :DictionaryFormatterBase<AttributeType,object, Event>
    {
       protected override Event Create(int count)
       {
           return new Event();
       }
       protected override void Add(Event collection, int index, AttributeType key, object value)
       {
           collection.Add(key, value);
       }
    }
    // and register it.
    MessagePack.Resolvers.CompositeResolver.RegisterAndSetAsDefault(
    new[] { new EventFormatter() },
    new[] { StandardResolver.Instance });
