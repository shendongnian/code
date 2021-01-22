    public bool IsValid(object input){
      foreach(var validator in this.Validators)
        if(!validator.IsValid(input)
          return false;
      return true;
    }
