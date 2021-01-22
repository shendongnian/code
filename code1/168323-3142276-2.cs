    public interface IMultiDimensional<T> {
      int Dimensions {
        get;
      }
      int Rank(int dimension);
    }
    
    public interface I1Dimensional<T>: IMultiDimensional<T> {
      T this[int index] {
        get;
        set;
      }
    }
    
    public interface I2Dimensional<T>: IMultiDimensional<T> {
      T this[int index1, int index2] {
        get;
        set;
      }
    }
    
    public interface I3Dimensional<T>: IMultiDimensional<T> {
      T this[int index1, int index2, int index3] {
        get;
        set;
      }
    }
    
    public interface I4Dimensional<T>: IMultiDimensional<T> {
      T this[int index1, int index2, int index3, int index4] {
        get;
        set;
      }
    }
    public static TDimensional CreateMulti<TDimensional, TType>() where T: IMultiDimensional<TType> {
      // emit a class with Reflection.Emit here that implements the interface
    }
    I4Dimensional<string> four = CreateMulti<I4Dimensional<string>, string>();
    four[1,2,3,4] = "abc";
