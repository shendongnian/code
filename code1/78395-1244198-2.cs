    public interface IHelper
    {
       IMyObj GetBasic();
       IMyObj GetExisting();
    }
    public interface IHelper<T> : IHelper
    {
       T GetBasic();
       T GetExisting();
    }
