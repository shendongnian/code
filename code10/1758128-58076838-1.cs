csharp
using System.ComponentModel.DataAnnotations.Schema;
namespace MyApp {
  public class MyEntity {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
  }
}
If the entities are related as zero/one to many you can also set the id of the related entity as the Key property
csharp
using System.ComponentModel.DataAnnotations;
namespace MyApp {
  public class MyForeignEntity {
    public int Id { get; set; }
  }
  public class MyEntity {
    [Key]
    public int ForeignId { get; set; }
    public virtual MyForeignEntity Foreign { get; set; }
  }
}
In which case the id is already set up to work.
