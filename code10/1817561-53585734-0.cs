    public static async Task Transaction(int[] productId)
        {
            try
            {
                //TODO: Check if product is in stock
    
                Dictionary<string,string> parameters = new Dictionary<string, string>();
                parameters["payment_method"] = "cash";
                parameters["set_paid"] = "true";
                parameters["line_items"] = ??
                var lineItems = new List<OrderLineItem>();
                lineItems.Add(new OrderLineItem());
                await wc.Order.Add(new Order(){ line_items = lineItems }, parameters);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
