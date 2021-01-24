    public class Content<T> where T:ContentProperties 
    {
    	public T Properties {get;set;}
    }
    
    public class Text : Content<TextProperties>
    {
    	public TextProperties Properties {get;set;}
    }
    
    public class Image : Content<ImageProperties>
    {
    	public ImageProperties Properties {get;set;}
    }
