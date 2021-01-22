	public class DisposableSpinLock : IDisposable {
		private SpinLock mylock;
		private bool isLocked;
		public DisposableSpinLock( SpinLock thelock ) {
			this.mylock = thelock;
			mylock.Enter( ref isLocked );
		}
		public DisposableSpinLock(  SpinLock thelock, bool tryLock) {
			this.mylock = thelock;
			if( tryLock ) {
				mylock.TryEnter( ref isLocked );
			} else {
				mylock.Enter( ref isLocked );
			}
		}
		public bool IsLocked { get { return isLocked; } }
		public void Dispose() {
			Dispose( true );
			GC.SuppressFinalize( this );
		}
		protected virtual void Dispose( bool disposing ) {
			if( disposing ) {
				if( isLocked ) {
					mylock.Exit();
				}
			}
		}
	}
