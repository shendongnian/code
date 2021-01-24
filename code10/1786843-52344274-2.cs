      public class Wine
            {
                public decimal Price;
                public int Year;
                public static int wineCategory = 8;
                public int capturedCategory; 
                public int capturedCategory2; 
                public int vote;    
                public Wine(decimal price)
                {
                    Price = price;
                }
    
                public Wine(decimal price, int year) : this(price)
                {
                    Year = year;
                }
    
                public Wine(decimal price, DateTime year) : this(price, year.Year)
                {
                }
    
                public Wine(decimal price, DateTime year, int wineCategory) : this(price, year.Year)
                {
                    capturedCategory = wineCategory; 
                }
                //in  this overload I  can use the static property 
                public Wine(decimal price, DateTime year, int wineCategory,int vote) : this(price, new DateTime(year.Year,1,1),Wine.wineCategory)
                {
                    vote= vote;
                }
               // but I can't do this 
                public Wine(decimal price, DateTime year, int wineCategory,int vote) : this(price, new DateTime(year.Year,1,1),this.capturedCategory)
                {
                    vote =vote;
                }
 
    
            }
