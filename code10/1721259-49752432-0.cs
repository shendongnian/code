    `try {
       //_applicationDbContext.SaveChanges() 
      throw new Exception();
    
      // Remember to replace _applicationDbContext.SaveChanges() with 
      //'new Exception' when you are outside of the development db
      return(true); //never hit
    }
    catch (Exception e) {
      //Error handling here
      return(false);
    }`
