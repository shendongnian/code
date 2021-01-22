         Predicate<Characteristic> criteria = delegate (Characteristic interest) 
         {
              return interest.CharacteristicType == "Interest";
         };
         List<string> myList = new List<string>();
         foreach(Characteristic c in customer.Characteristics)
         {
            if(criteria(c))
            {
                myList.Add(c.CharacteristicValue);
            }
         }
