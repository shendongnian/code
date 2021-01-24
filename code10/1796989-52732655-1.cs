    if (id != -107 || totalAllTk + qty > 24) {   // Running your code here
      if (itemExists)
      {
         Cart exists = (from item in db.Carts
         where item.ProductId == id && item.SessionId == sessionId && item.SizeId == id select item).FirstOrDefault();
         newQuantity = exists.Quantity + qty;
         exists.Quantity = newQuantity;
         db.SaveChanges();
      }
      else
      {
        Cart newItem = new Cart()
        {
             ProductId = id,
             CreatedBy = userID,
             SessionId = sessionId,
             Quantity = qty,
             SizeId = id,
             Size = tkType,
             CreatedOn = DateTime.Now.ToUniversalTime()
        };
        db.Carts.Add(newItem);
        db.SaveChanges();
        newQuantity = qty;
      }
    }
    else {statusChk = "FULL";
       
    }
