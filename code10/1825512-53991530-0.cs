    public class JsonResolver : DefaultContractResolver
    {
        ...
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var serializableMembers = base.GetSerializableMembers(objectType).Select(memberInfo => memberInfo.Name);
            return objectType.GetProperties().Where(memberInfo => serializableMembers.Contains(memberInfo.Name)).Cast<MemberInfo>().ToList();
        }
    
        ...
    }
