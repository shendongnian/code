    // Generate elements for each product  
    foreach (var product in productList)  
    {  
       Button btn = new Button();  
       btn.CommandArgument = product.ID; // This would be your product ID  
       btn.Text = "Buy Now";  
       btn.Click += Btn_Click;  
        
       this.Products.Controls.Add(btn);  
    }
