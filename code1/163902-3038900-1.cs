       List<IProduct> OrderedProducts
       {
          get { return this.L2SQLProducts.Cast<IProduct>.ToList(); }
          set { 
               this.L2SQLProducts = new EntitySet<IProduct>();
               foreach (var entry in value)
                  this.L2SQLProducts.Add(entry);
          }
       }
