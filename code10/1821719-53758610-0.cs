    class Address
    {
         public int Id {get; set;}
         ... // other properties
         // every Address has sent zero or more delivery Notes (one-to-many)
         public virtual ICollection<DeliveryNote> SentNotes {get; set};
         // every Address has received zero or more delivery Notes (one-to-many)
         public virtual ICollection<DeliveryNote> ReceivedNotes {get; set};
    }
    class DeliveryNote
    {
         public int Id {get; set;}
         ... // other properties
        
         // every DeliveryNote comes from an Address, using foreign key
         public int FromId {get; set;}
         public virtual Address FromAddress {get; set;}
         // every DeliverNote is sent to an Address, using foreign key:
         public int ToId {get; set;}
         public virtual Address ToAddress {get; set;}
    }
