csharp
using System.ComponentModel.DataAnnotations.Schema;
namespace MyApp {
  public class MyEntity {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
  }
}
