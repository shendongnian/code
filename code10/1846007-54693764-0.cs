c#
public class Article: MyEntityBase
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } 
    public int ArticlePhotoId { get; set; }
    //Common Photo property
    //One article has one photo
    public Photo ArticlePhoto { get; set; }
}
your photo object looks correct with the `CenterId` the line below it remove the `virtual`
in your Center object, use `ICollection` instead of `List`
the rest should just map automatically without a configuration file.
