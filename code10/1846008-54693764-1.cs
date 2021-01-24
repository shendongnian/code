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
Edit:
On regards to `virtual` if you are using lazy loading then it seems to be supported, but configuration is needed to set that up. I'd keep things as simple as possible first and verify that it works then add lazy loading.
reference: https://stackoverflow.com/questions/41881169/navigation-property-should-be-virtual-not-required-in-ef-core
