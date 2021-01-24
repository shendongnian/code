    public interface IContentSource<out T> where T : Content{}
    
    public class SourceX : IContentSource<ContentA>{}
    
    public class SourceY : IContentSource<ContentB>{}
    var ContentSources = new List<IContentSource<Content>>
	{
		new SourceX(),
	    new SourceY(),
	};
