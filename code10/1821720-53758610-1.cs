    IQueryable<DeliveryNote> deliveryNotes = dbContext.DeliveryNotes
       .Where (deliveryNote => ...) // probably something with Id, or Date, or subject
       .Select(deliveryNote => new
       {
           // select only the delivery note properties you actually plan to use
           Subject = deliveryNote.Subject,
           DeliveryDate = deliveryNote.DeliveryDate,
           ...
           From = new
           {
               // select only the From properties you plan to use
               Id = deliveryNote.FromAddress.Id,
               Name = deliveryNote.FromAddress.Name,
               Address = deliveryNote.FromAddress.Address,
               ...
           }
           To = new
           {
                // again: only properties you'll use
                Name = deliveryNote.ToAddress.Name,
                ...
           },
       });
