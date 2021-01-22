    public class Man
    {
       [Order(0)]
       string Name {get; set;}
       [Order(1)]
       int virtual Age {get; set;}
    }
    public class SuperMan:Man
    {
       [Order(-1)]
       override int Age {get; set;}
    }
