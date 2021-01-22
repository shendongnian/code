    public interface IMeasurementInterface
    {
      void Initialize();
      void Close();
      void Setup( IConfigurer config );
    }
    
    public interface IConfigurer
    {
      void ApplyTo( object obj );
    }
    
    public abstract ConfigurerBase<T> : IConfigurer where T : IMeasurementInterface
    {
      protected abstract void ApplyTo( T item );
      
      void IConfigurator.ApplyTo(object obj )
      {
        var item = obj as T;
        if( item == null )
          throw new InvalidOperationException("Configurer can't be applied to this type");
        ApplyTo(item);
      }
    }
