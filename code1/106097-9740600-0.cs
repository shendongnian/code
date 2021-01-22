    Colour eco;
    if(Enum.TryParse("17", out eco)) //Parse successfully??
    {
      var isValid = Enum.GetValues(typeof (Colour)).Cast<Colour>().Contains(eco);
      if(isValid)
      {
         //It is really a valid Enum Colour. Here is safe!
      }
    }
