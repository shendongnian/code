    public interface IZeroWrapper<TNumber> {
      TNumber Zero {get;}
    }
    public class DoubleWrapper: IZeroWrapper<double> {
      public double Zero { get { return 0; } }
    }
