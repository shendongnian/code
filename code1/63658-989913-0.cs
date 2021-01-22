    interface ISumT<T>
    {
      /// <summary>
      /// the sum method adds rhs to this and returns the result
      /// </summary>
      /// <remark>
      /// use a interface (i.e. ISumT)
      /// with a method (i.e. sum)
      /// because "where" doesn't support operators
      /// </remark>
      T sum(T rhs);
    }
    
    public class AutoAverage<T> where T : ISumT<T>
    {
      public T NextAvg( T newValue )
      {
        // can assume that T implements the sum method
      }
    }
