     [__DynamicallyInvokable]
        public IEnumerable<T> GetConsumingEnumerable(CancellationToken cancellationToken)
        {
          ...
            while (!this.IsCompleted)
            {
              T obj;
              if (this.TryTakeWithNoTimeValidation(out obj, -1, cancellationToken, linkedTokenSource))
                yield return obj;
            }
          ...
        }
