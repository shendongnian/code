	public abstract class BaseStyleType {}
	public class ImageStyle  : BaseStyleType {}
	public class TextStyle   : BaseStyleType {}
	public class ButtonStyle : BaseStyleType {}
	
	// NOT THREAD SAFE
	public class GlobalStyle
	{
       // 
       private Dictionary<Type,List<BaseStyleType>> _lists = 
         new Dictionary<Type,List<BaseStyleType>>();
       // Not sure why you'd use Fields here...
       public IEnumerable<ImageStyle> ImageStyles
       {
         get 
         {
           IEnumerable<ImageStyle> result = null;
		   List<BaseStyleType> list;
           if (_lists.TryGetValue(typeof(ImageStyle), out list))
           {
             result = list.Cast<ImageStyle>();
           }
		   return result;
         }
       }
       //etc
       //public List<ImageStyle>  ImageStyles     = new List<ImageStyle>();
	   //public List<TextStyle>   TextStyles      = new List<TextStyle>();
	   //public List<ButtonStyle> ButtonStyles    = new List<ButtonStyle>();
   	   // Setter
	   public void SetStyle<T>(T inStyle)
		   where T : BaseStyleType
  	   {
		   List<BaseStyleType> list;
           if (_lists.TryGetValue(typeof(T), out list))
           {
             list.Add(inStyle);
           }
		   else
		   {
			   list = new List<BaseStyleType>();
			   list.Add(inStyle);
			   _lists.Add(typeof(T), list);
		   }
	   }
	}
