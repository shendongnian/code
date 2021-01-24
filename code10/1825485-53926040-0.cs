    public interface IContentManagerUnitOfWork
    {
        IEnumerable<List> GetLists();
        List CreateList(ListCreationInformation listCreationInformation);
        List GetListByTitle(string title);
        [...]
    }
