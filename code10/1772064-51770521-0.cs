    public class GetAttribute: Attribute {}
    public class PostAttribute: Attribute {}
    public class PatchAttribute: Attribute {}
    public class DeleteAttribute: Attribute {}
    [GET] [DELETE]
    public long? IdExample { get; set; }
