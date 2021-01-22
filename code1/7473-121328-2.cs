        public class Manufacturer
        {
           long Id {get; set;}
           String Name {get; set;}
           
           public override string ToString()
           {
              return Name;
           }
        }
