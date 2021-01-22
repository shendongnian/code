    // Create new entities
    Cart c = new Cart();
    CartEntry ce = new CartEntry();
    ce.Cart = c;
    // Delete the entry
    c.CartEntries.Remove(ce);
    dc.Cartentries.Attach(ce);
    dc.CartEntries.DeleteOnSubmit(ce);
    // Insert the cart into database
    dc.Carts.InsertOnSubmit(c);
    dc.SubmitChanges();
