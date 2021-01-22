    public class BrokenRulesCollectionResolver :
        ValueResolver<DomainObjects.Members.IMemberRegistration, StatusMessageList>
    {
        protected override StatusMessageList ResolveCore(
            DomainObjects.Members.IMemberRegistration source)
        {
            var messageList = new StatusMessageList();
            messageList.ReadBrokenRules(source.BrokenRules);
            return messageList;
        }
    }
