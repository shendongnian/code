    [Test]
    public void Find()
    {
      var animalRepository = new AnimalRepository();
      animalRepository.Add( dog ); // create a object to species = dog and other relevant attr
      animalRespository.Add( cat ); // etc. etc..
    
      var results = animalRepository.Find( a => a.Species == "Cat");
    
      Assert.That( results.Is.EquivalentTo( new List<Animal> { cat } ) );
    }
