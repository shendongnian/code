    public class Animal
    {
        private int _animalId;
    
        public virtual int AnimalId
        {
            get { return _animalId; }
        }
    }
    
    public class Dog : Animal
    {
        public override int AnimalId
        {
            get 
            { 
                if (Request.Params["New_Animal"] == "true")
                    return -1;
                else
                    return base.AnimalId;
            }
        }
    }
