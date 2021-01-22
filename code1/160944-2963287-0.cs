Just for sanity's sake, why not use Dictionary&lt;Type, IParameter&gt;?  With a little generics, you could do this:
    public interface IParameter { }
    public class FP12 : IParameter { public string fieldFP12 { get; set; } }
    public class FP11 : IParameter { public string fieldFP11 { get; set; } }
    
    public static class DictionaryHelper
    {
        public static T GetParameter<T>(this Dictionary<System.Type, 
          IParameter> target) where T : IParameter
        {
            return (T)target[typeof(T)];
        }
    }
