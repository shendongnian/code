    public Contact CreateContact(Contact contact){
        contact.ConvertContactRelationToReference();
        _entities.AddToContact(contact); 
        //throws the exception
        _entities.SaveChanges();
        contact.ContactRelation.Load();
        return contact;
    }
    
    public partial class Contact
    {
      public void ConvertContactRelationToReference()
      {
        var crId = ContactRelation.Id;
        ContactRelation = null;
        ContactRelationReference.EntityKey = new EntityKey("MyEntities.ContactRelations", "Id", crId);
      }
    }
