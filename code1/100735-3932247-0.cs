public interface IService
{
    [OperationContract]
    List<ContentItem> GetContentList();
}
[DataContract]
public class ContentItem
{
  [DataMember] public string Name;
  [DataMember] public object Data;
}
