    public interface ITag : IObservable<ITag>, IObserver<ITag>, IDisposable
    {
      Type TagType { get; }
      bool SubscribeToTag( ITag tag );
    }
    public class Tag : ITag
    {
      protected readonly List<Subscription> observables = new List<Subscription>( );
      protected readonly List<IObserver<ITag>> observers = new List<IObserver<ITag>>( );
      bool disposedValue = false;
      protected Tag( ) { }
      IDisposable IObservable<ITag>.Subscribe( IObserver<ITag> observer )
      {
        if ( !observers.Contains( observer ) )
        {
          observers.Add( observer );
          observer.OnNext( this ); //--> or not...maybe you'd set some InitialSubscription state 
                                   //--> to help the observer distinguish initial notification from changes
        }
        return new Subscription( this, observer, observers );
      }
      public bool SubscribeToTag( ITag tag )
      {
        if ( observables.Any( subscription => subscription.Tag == tag ) ) return false; //--> could throw here
        observables.Add( ( Subscription ) tag.Subscribe( this ) );
        return true;
      }
      protected void Notify( ) => observers.ForEach( observer => observer.OnNext( this ) );
      public virtual void OnNext( ITag value ) { }
      public virtual void OnError( Exception error ) { }
      public virtual void OnCompleted( ) { }
      public Type TagType => GetType( );
      protected virtual void Dispose( bool disposing )
      {
        if ( !disposedValue )
        {
          if ( disposing )
          {
            while ( observables.Count > 0 )
            {
              var sub = observables[ 0 ];
              observables.RemoveAt( 0 );
              ( ( IDisposable ) sub ).Dispose( );
            }
          }
          disposedValue = true;
        }
      }
      public void Dispose( )
      {
        Dispose( true );
      }
      protected sealed class Subscription : IDisposable
      {
        readonly WeakReference<Tag> tag;
        readonly List<IObserver<ITag>> observers;
        readonly IObserver<ITag> observer;
        internal Subscription( Tag tag, IObserver<ITag> observer, List<IObserver<ITag>> observers )
        {
          this.tag = new WeakReference<Tag>( tag );
          this.observers = observers;
          this.observer = observer;
        }
        void IDisposable.Dispose( )
        {
          if ( observers.Contains( observer ) ) observers.Remove( observer );
        }
        public Tag Tag
        {
          get
          {
            if ( tag.TryGetTarget( out Tag target ) )
            {
              return target;
            }
            return null;
          }
        }
      }
    }
