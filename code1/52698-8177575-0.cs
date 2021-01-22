    namespace MyNS 
    { 
       public class Dog 
       { 
          public int Legs { get; set; } 
          public string Name { get; set; } 
          public string Breed { get; set; } 
       }
       public class DogBll
       {
          private List<Dog> myDog;
          public DogBll()
          {
              myDog = new List<Dog>();
          }
          public List<Dog> GetDogs()//You can use a parameter here but make sure you define  the parameter in object datasource
          {
              return myDog;
          }
    
    } 
