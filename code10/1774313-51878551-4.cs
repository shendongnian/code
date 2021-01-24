    public class Zoo
    {
        public Cat [] arcats;
        public void CreateZoo(int counter)
        {
            arcats = new Cat[counter];
        }
    
        public void AddCat(int counter, Cat cat)
        {
            arcats[counter] = cat;
        }
        public bool IsZooFull()
        {
            if (arcats.Length > 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public double GetAvgWeight()
        {
            double totalWeight = 0.0;
            foreach(Cat cat in arcats) // Loop through all the cats in arcats and add all their weights
            {
                totalWeight += cat.GetWeight();
            }
            return totalWeight / arcats.Length; // Divide total weight by number of cats
        }
    }
