     class InventoryAndSales
        {
            public virtual int GetTotalSales(int a, int b)
            {
                return a + b;
            }
        }
         
        class NewInventoryAndSales : InventoryAndSales
        {
            //it replaces the implementation in parent class
            public override int GetTotalSales(int a, int b)
            {
                return a * b;
            }
        }
