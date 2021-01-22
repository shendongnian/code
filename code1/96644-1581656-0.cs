    public class Pet { 
      ...
      public string PetTypeName { 
        get { 
          PetType pt = getPetTypeById(PetTypeID); // this method is up to you to write, of course
          return pt.Description;
        } 
      }
      ...
    }
