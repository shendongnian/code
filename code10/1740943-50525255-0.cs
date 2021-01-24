    public interface IPageModel<T>
    {
        int CurrentPage { get; set; }    
        T GetLinkParameter<T>();
    }
    public class PageModel : IPageModel<IMyInterface>
    {
        public int CurrentPage { get; set; }
    
        IMyInterface GetLinkParameter()
        {
            return new DefaultPageParameterExt()
            {
                Pagenumber = CurrentPage,
                PerPage = CurrentPerPage
            };
        }
    }
