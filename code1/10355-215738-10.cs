    sealed class LockedList<T> : Locked<List<T>, ReadOnlyCollection<T>> {
      public LockedList( )
        : base( new List<T>( ), list => list.AsReadOnly( ) )
      { }
    }
    public class Locked<W, R> where W : class where R : class {
      private readonly LockerState state_;
      public Locked( W writer, R reader ) { this.state_ = new LockerState( reader, writer ); }
      public Locked( W writer, Func<W, R> getReader ) : this( writer, getReader( writer ) ) { }
      
      public IReadable Read( ) { return new Readable( this.state_ ); }
      public IWritable Write( ) { return new Writable( this.state_ ); }
      public IUpgradable UpgradableRead( ) { return new Upgradable( this.state_ ); }
      
      
      public interface IReadable : IDisposable { R Reader { get; } }
      public interface IWritable : IDisposable { W Writer { get; } }
      public interface IUpgradable : IReadable { IWritable Upgrade( );}
      
      
      #region Private Implementation Details
      sealed class LockerState {
        public readonly R Reader;
        public readonly W Writer;
        public readonly ReaderWriterLockSlim Sync;
        
        public LockerState( R reader, W writer ) {
          Debug.Assert( reader != null && writer != null );
          this.Reader = reader;
          this.Writer = writer;
          this.Sync = new ReaderWriterLockSlim( );
        }
      }
      
      abstract class Accessor : IDisposable {
        private LockerState state_;
        protected LockerState State { get { return this.state_; } }
        protected Accessor( LockerState state ) {
          Debug.Assert( state != null );
          this.Acquire( state.Sync );
          this.state_ = state;
        }
        
        protected abstract void Acquire( ReaderWriterLockSlim sync );
        protected abstract void Release( ReaderWriterLockSlim sync );
        
        public void Dispose( ) {
          if( this.state_ != null ) {
            var sync = this.state_.Sync;
            this.state_ = null;
            this.Release( sync );
          }
        }
      }
      
      class Readable : Accessor, IReadable {
        public Readable( LockerState state ) : base( state ) { }
        public R Reader { get { return this.State.Reader; } }
        protected override void Acquire( ReaderWriterLockSlim sync ) { sync.EnterReadLock( ); }
        protected override void Release( ReaderWriterLockSlim sync ) { sync.ExitReadLock( ); }
      }
      
      sealed class Writable : Accessor, IWritable {
        public Writable( LockerState state ) : base( state ) { }
        public W Writer { get { return this.State.Writer; } }
        protected override void Acquire( ReaderWriterLockSlim sync ) { sync.EnterWriteLock( ); }
        protected override void Release( ReaderWriterLockSlim sync ) { sync.ExitWriteLock( ); }
      }
      
      sealed class Upgradable : Readable, IUpgradable {
        public Upgradable( LockerState state ) : base( state ) { }
        public IWritable Upgrade( ) { return new Writable( this.State ); }
        protected override void Acquire( ReaderWriterLockSlim sync ) { sync.EnterUpgradeableReadLock( ); }
        protected override void Release( ReaderWriterLockSlim sync ) { sync.ExitUpgradeableReadLock( ); }
      }
      #endregion
    }
