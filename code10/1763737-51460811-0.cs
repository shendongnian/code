    [Table("user")]
    public class User
    {
    [Key,Column("id")]
    public string Id {get; set;
    [ForeignKey(nameof(Id))]
    public virtual ICollection<UserShips> UserShips { get; set; }
    // other properties ...
    }
    [Table("ship")]
    public class Ship
    {
    [Key, Column("shipid")]
    public int ShipId {get; set;}
    [ForeignKey(nameof(ShipId))]
    public virtual ICollection<UserShips> UserShips { get; set; }
    // other ship properties
    }
    [Table("userships")]
    public class UserShips 
    {
    [Key,Column("usershipid")]
    public int UserShipId {get; set;}
    [Column("shipid")]
    public int ShipId {get; set;}
    [Column("id")]
    public string Id {get; set;}
    [ForeignKey(nameof(Id))]
    public virtual User User {get; set;}
    [ForeignKey(nameof(ShipId))]
    public virtual Ship Ship {get; set;}
    }
