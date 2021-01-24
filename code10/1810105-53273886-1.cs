    List<Item> cart = new List<Item>();
    
    if (!string.IsNullOrEmpty(Session["cart"] as string))
    {
        cart = JsonConvert.DeserializeObject<List<Item>>(Session["cart"].ToString());
        // use mapping here
    }
    else
    {
        // do something else
    }
