    public class ClientObj{
        public void doStuff(){
        Animal a=getAnimal();
        if(a is Dog){
           DogLeg dl = (DogLeg)a.GetLeg();
        }
      }
    }
