    public class Content<T> where T : ContentProperties 
    {
    	public T Properties {get;set;}
    }
    
    public class Text : Content<TextProperties>
    {
    }
    
    public class Image : Content<ImageProperties>
    {
    }
