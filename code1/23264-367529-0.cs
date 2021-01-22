    internal interface IAMSaver { void Save(IAM item); }
    internal class AMSaverFactory {
      IAMSaver GetSaver(Type itemType) { ... }
    }
    
    public class MyList : List<IAM>
    {
      public void Save()
      {
        foreach (IAM itemin this)
        {
          IAMSaver saver = SaverFactory.GetSaver(item.GetType());
          saver.Save(item)
        }
      }
    }
