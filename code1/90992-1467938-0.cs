    public interface IEnglish
    {
     public string DescriptionEN { get; }
    }
    
    public interface IFrench
    {
     public string DescriptionFR { get; }
    }
    
    public interface IMultilingual : IEnglish, IFrench { }
    
    public void desc<T>(ref T o, string propPrefix) where T : IMultilingual
    {
     return Sess.lang = Sess.elang.en ? o.DescriptionEN : o.DescriptionFR
    }
