    abstract class Animal : Organism
    {
        public virtual bool EatsPlants
        {
            get { return false; }
        }
    
        public virtual void EatPlant(Plant food)
        {
            throw new NotSupportedException();
        }
    
        public virtual bool EatsAnimals
        {
            get { return false; }
        }
    
        public virtual void EatAnimal(Animal food)
        {
            throw new NotSupportedException();
        }
    }
    class Herbivore : Animal
    {
        public override bool EatsPlants
        {
            get { return true; }
        }
    
        public override void EatPlant(Plant food)
        {
            // whatever
        }
    }
