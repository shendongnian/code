        [Test]
        public void CanSaveAndRetrievePetAttachedToPerson()
        {
            Person person = new Person("Joe");
            person.AddPet(new Pet("Fido"));
            
            Session.Save(person);
            Person retrievedPerson = Session.Get<Person>(person.Id);
            Assert.AreEqual("Fido", retrievedPerson.Pets.First().Name);
        }
