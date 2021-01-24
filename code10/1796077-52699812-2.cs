    Predicate<Address> countryPred = new Predicate<Address>(a => a.country == country);
    Predicate<Address> streetPred = new Predicate<Address>(a => a.street == street);
    Predicate<Address> pinPred = new Predicate<Address>(a => a.pin== pin);
    
    Predicate<Address> finalPred;
    if(string.IsNullOrEmpty(country))
    {
       if(finalPred == null)
          finalPred = countryPred;
       else
          finalPred = c => finalPred (c) || countryPred (c);
    }
    ..
    ..
    ..
    
    c = c.Where(x=> x.Lead.Address.Any(s=> finalPred));
