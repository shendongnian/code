    using System;
    using System.Collections.Generic; // required for List<>
    namespace WidowsFormsApplication
    {
        public class ShoppingCart
        {
            List<double> shoppingCart = new List<double>();
            
            protected void AddItemToCart()
            {
                shoppingCart.Add(450);
            }
    
            protected void UpdateShoppingCart()
            {
                double total = 0;
                foreach (double item in shoppingCart)
                {
                    total += item;
                }
                if (Double.TryParse(txt_DeliveryCharges.Text, out double charges))
                {
                    total += charges;
                    lbl_TotalAmount.Text = String.Format("{0:0.00}", total);
                }
            }
        }
    }
