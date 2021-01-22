    public class Dog{
        public Leg GetLeg(){
             DogLeg dl = super.GetLeg();
             //set doglet specific properties
    }
    }
    
    
        Animal a = getDog();
        Leg l = a.GetLeg();
        l.kick();
