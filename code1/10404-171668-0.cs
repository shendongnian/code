       public T Evaluate<T>(T x, T y) {
          switch (Operation)
          {
            case BinaryOp.Add:
                return Operator.Add(x, y);
            case BinaryOp.Subtract:
                return Operator.Subtract(x, y);
         ... etc
