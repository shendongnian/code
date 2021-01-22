    public interface IStillNeedsMixing : ICanAddColours
    {
         Bucket Mix();
    }
    public interface ICanAddColours
    {
         IStillNeedsMixing Red(int red);
         IStillNeedsMixing Green(int green);
         IStillNeedsMixing Blue(int blue);
    }
