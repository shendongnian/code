    var query = dbContext.Addresses
        .Where(address => address.City == "New York" && ...)
        .Select(address => new
        {
             // only properties you plan to use
             Id = address.Id,
             Name = address.Name,
             ReceivedNotes = address.ReceivedNotes
                 .Where(note => note.DeliveryDate.Year == 2018)
                 .Select(note => new
                 {
                     // only properties you plan to use:
                     Title = note.Title,
                     ...
                     // no need for this, you know it equals Id
                     // AddressId = note.FromId,
                 }),
        });
