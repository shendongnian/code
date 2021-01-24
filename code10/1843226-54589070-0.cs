     public ActionResult DisplayElements()
    {          
        dictionaryOfElements.Add(Hydrogen.AtomicNumber, Hydrogen);
        dictionaryOfElements.Add(Helium.AtomicNumber, Helium);
        dictionaryOfElements.Add(Lithium.AtomicNumber, Lithium);
        dictionaryOfElements.Add(Beryllium.AtomicNumber, Beryllium);
    
        return View(new ElementsOfPeriodicTable{
                                              dictionaryOfElements=dictionaryOfElements
                                               }
                 );
    }
