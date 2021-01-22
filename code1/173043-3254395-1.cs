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
//
     private void button1_Click(object sender, EventArgs e)
        {
           
             Factory[] obj = new Factory[1];
              obj[0] =new NissanFactory();
            private List<iProduct> products = new List<iProduct>();
  
            //create maxima if it's chacked
            if (checkBox2.Checked)
               products.Add(obj.CreateProduct(1));
               
             //create ultima
            if (checkBox1.Checked)
                products.Add(prod = obj.CreateProduct(2));
            //now you can navigate via list of created products
            foreach (IProduct car in products)
            {
              
               
                    prod.GetDetails();
                
            }
        }
