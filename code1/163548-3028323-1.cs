    // assign data
    byte[] imageByteArray = ...some byte data...;
    myObject.Image = new Binary(imageByteArray);
    // save to db
    dataContext.YourTable.InsertOnSubmit(myObject); //YourTable is the name of your actual table class
    dataContext.SubmitChanges();
