      class cat_adapter : IAnimal
      {
           private cat baseCat;
           public cat_adapter( cat aCat)
           {
               baseCat = aCat;
           }
           // Implement IAnimal interface and redirect to baseCat
           public void eat()
           {
                baseCat.munchOnMeowMix();
           }
           
      }
