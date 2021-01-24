     public class ClassD : ClassA
     {
         public string Name {get; }
         public ClassD() : this(null)
         { }
         public ClassD(string message) : base(message)
         {
             this.Name = nameof(ClassD);
         }
     }
