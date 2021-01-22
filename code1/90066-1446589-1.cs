    [ProtoContract]
    public class Person {
       [ProtoMember(1)]
       public int Id {get;set;}
       [ProtoMember(2)]
       public string Name {get;set;}
    }
    ....
    Person person = new Person { Id = 123, Name = "abc" };
    Serializer.Serialize(destStream, person);
    ...
    Person anotherPerson = Serializer.Deserialize<Person>(sourceStream);
