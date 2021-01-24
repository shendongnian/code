    class Person {
      public Phone Phone { get; private set; }
    
      public void ExposePhoneNumberPublic() {
        if(!this.WantsToBeContactedAtAll)
          throw new SomeError("Not allowed.");
        Phone = new Phone(Phone.Number, Phone.Description, shouldBePublished: true);
      }
    }
