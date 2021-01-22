    //Using declarations ommitted for brevity.
    
    public class Person{
       public Guid ID;
       public string Name;
    
       public Person (string _name){
          this.Name = _name;
          ID = System.Guid.NewGuid();//creates a unique identifier
       }
    
       public void testMethod(){
          Console.WriteLine("This code is running inside a Person object: " + this.Identify());
          Person g1, g2, g3;
    
          g1 = new Person("Nadeem");
          g2 = new Person("Anish");
          g3 = new Person("Frank");
    
          this.Identify();// this tells you which class the code is running in - ie. what 'this' means in this context.
          
          //These are the additional objects you created by running testmethod from inside "Jim", the first person you created.
     
          g1.Identify();
          g2.Identify();
          g3.Identify();
    
          //If you want to get really funky, you can call testMethod() on g1, g2 and g3 too.
          //the ID field should help you see what's going on internally.
    
       }
    
    
       public void Identify(){
          Console.WriteLine("Person: ID=" + this.ID + "Name = " + this.Name);//Use string.format in production code!
       }
    
       public static void main (string[] args){
          Person p = new Person ("Jim");
    
          p.testMethod();
       }
    
    }   
