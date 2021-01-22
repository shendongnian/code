    [Table(Name="Contact")]
    public class Contact
    {
       [Column(Id=true)]
       public int ContactID;
       [Column]
       public string BillingAddressID;
       private EntityRef<BillingAddress> _BillingAddress;    
       [Association(Storage="_BillingAddress", ThisKey="BillingAddressID")]
       public BillingAddress BillingAddress {
          get { return this._BillingAddress.Entity; }
          set { this._BillingAddress.Entity = value; }
       }
    }
    [Table(Name="BillingAddress")]
    public class BillingAddress
    {
       [Column(Id=true)]
       public string BillingAddressID;
       ...
       private EntitySet<Contact> _Contacts;
       [Association(Storage="_Contacts", OtherKey="BillingAddressID")]
       public EntitySet<Contact> Contacts {
          get { return this._Contacts; }
          set { this._Contacts.Assign(value); }
       }
    }
    
