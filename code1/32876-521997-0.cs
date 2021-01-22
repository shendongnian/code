    try{
       MyMethod(obj);
    }catch (NullReferenceException ne){
       //do something
    }
    catch(UnauthorizedAccessException uae){
       //do something else
    }
    catch(System.IO.IOException ioe){
       //do something else
    }
    catch(Exception){
       //do something else
    }
     
