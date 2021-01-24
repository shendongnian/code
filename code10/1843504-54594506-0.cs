c#
public class User {
    public int Id { get; set; }
    public int PrimaryAddressId { get; set;}
    public virtual Address PrimaryAddress { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }
}
EF should automagically make the relationship between PrimaryAddressId and the navigational property.
you don't really want that magic configuration thing... unless you mean to always have the same Address as the PrimaryAddress, then you can do that as a default value instead... but that seems to be a code smell and probably don't want to do that?
