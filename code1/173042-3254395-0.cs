     abstract class Factory
    {
        public abstract iProduct CreateProduct(int Model);
    }
    class NissanFactory : Factory
    {
        public override iProduct CreateProduct(int Model)
        {
            // say 1  is Maxima
            //say 2   is Untima 
            if (Model ==1)
            {
                return new NissanMaxima();
            }
            if(Model ==2)
            {
                return new NissanUltima();
            }
             return null;
        }
    }
    class FordFartory : Factory
    {
        public override iProduct CreateProduct(int Model)
        {
            if (Model == 1)
            {
                return new GrandTorino();
            }
            if (Model == 2)
            {
                return new Mustang();
            }
            return null;
        }
    }
