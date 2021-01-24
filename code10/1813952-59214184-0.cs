using System.ComponentModel.DataAnnotations.Schema;
Public Class Entry {
    public int Id { get; set; }
    public String Name { get; set; }
    public String Comment { get; set; }
    [NotMapped]
    public String Additional { get; set; }
}
This tells EF that the field is not a column in the database.
