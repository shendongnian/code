    public interface IDensity
    {
        int Density 
        { 
            get 
            {
                var weight=getWeight();
                if (weight==0) return 0;
                return getVolume()/weight;
            }
        }
    
        abstract int getWeight();
        abstract int getVolume();
    }
