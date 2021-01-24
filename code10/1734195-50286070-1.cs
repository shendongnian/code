     public class ClassD : ClassA
     {
         public string Name {get; }
         public ClassD() // will of course automatically call base()
         {
             this.Init();
         }
         public ClassD(string message) : base(message)
         {
             this.Init();
         }
         public void Init()
         {
             this.Name = nameof(ClassD);
         }
     }
