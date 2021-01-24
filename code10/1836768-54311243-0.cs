 c#
  [ProtoContract]
  public class UserDTO
  {
    [ProtoMember(1)]
    public string UserNumber { get; set; }
    [ProtoMember(3)]
    public string FirstName { get; set; }
    [ProtoMember(4)]
    public string LastName  { get; set; }
    [ProtoMember(2)]
    public string UserId { get; set; }
    [ProtoMember(5)]
    public string EmailId { get; set; }
  }
then assuming you already have your data in a `Stream` (if using `byte[]`, a `MemoryStream` will work):
    var userList = Serializer.Deserialize<List<UserDTO>>(source);
will give you a `List<UserDTO>`, making the (correct) assumption that each element is a `repeated Candidate` with field `1`. If you want to me more specific, you can run the entire proto schema through code-gen to get the full schema - for example via protobuf-net's [`protogen`](https://protogen.marcgravell.com/#g41678805d80870786eeb28af4ca8f82b). Hit "Generate" and you get an additional `CandidateList` element that represents the root object (rather than being implicit). Then you would use:
    var root = Serializer.Deserialize<CandidateList>(source);
    var userList = root.candidateLists;
In both cases, the same approach with `Serialize` instead of `Deserialize` will work to generate protobuf data from the input.
