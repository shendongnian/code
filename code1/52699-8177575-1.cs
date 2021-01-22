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
          public DogBll()
          {
          }
          public List<Dog> GetDogs(Lists<Dog> myDog)//make sure you set the parameter in object datasource
          {
              return myDog;
          }
        }
    } 
