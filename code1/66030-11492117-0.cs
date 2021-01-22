	/// <summary>
	/// Provides a wrapper around an SqlTransaction that raises events on commit and rollback
	/// </summary>
	public partial class CpoTransaction : IDisposable {
		private SqlTransaction mTransaction;
		private bool mHasEnded;
		public event EventHandler Committed, RolledBack;
		/// <summary>
		/// Provides a wrapper around an SqlTransaction that raises events on commit and rollback
		/// </summary>
		/// <param name="innerTransaction">The SqlTransaction to wrap</param>
		internal CpoTransaction(SqlTransaction innerTransaction) {
			mTransaction = innerTransaction;
			mHasEnded = false;
		}
		/// <summary>
		/// Rolls back the transaction from a pending state.
		/// </summary>
		internal void RollBack() {
			if (!mHasEnded) {
				mTransaction.Rollback();
				OnRolledBack(this, new EventArgs());
				mHasEnded = true;
			} else
				throw new InvalidOperationException("Transaction has already ended.");
		}
		/// <summary>
		/// Commits the database transaction
		/// </summary>
		internal void Commit() {
			if (!mHasEnded) {
				mTransaction.Commit();
				OnCommitted(this, new EventArgs());
				mHasEnded = true;
			} else
				throw new InvalidOperationException("Transaction has already ended.");
		}
		/// <summary>
		/// Add the SqlTransaction and its associated SqlConnection to the SqlCommand
		/// </summary>
		/// <param name="command">The command to add the SqlTransaction and SqlConnection to</param>
		internal void SetTransaction(SqlCommand command) {
			if (command == null)
				throw new ArgumentNullException("command");
			command.Connection = mTransaction.Connection;
			command.Transaction = mTransaction;
		}
		/// <summary>
		/// Gets whether or not the transaction has ended
		/// </summary>
		internal bool HasEnded {
			get { return mHasEnded; }
		}
		/// <summary>
		/// Gets the internal SqlConnection
		/// </summary>
		internal SqlConnection Connection {
			get { return mTransaction.Connection; }
		}
		/// <summary>
		/// Gets the internal SqlTransaction
		/// </summary>
		public SqlTransaction InnerTransaction {
			get { return mTransaction; }
		}
		/// <summary>
		/// Wraps an existing SqlTransaction into a CpoTransaction. IMPORTANT: See remarks!
		/// </summary>
		/// <param name="transaction">The transaction to wrap</param>
		/// <returns>The SqlTransaction wrapped in a CpoTransaction</returns>
		/// <remarks>
		/// Use this method to allow CPO actions to be performed within the context of an already
		/// existing transaction.
		/// Note however that if the SqlTransaction is committed or rolled back without the use of the 
		/// CpoTransaction's Commit/Rollback functions, the events will not fire.
		/// </remarks>
		public static CpoTransaction WrapTransaction(SqlTransaction transaction) {
			return new CpoTransaction(transaction);
		}
		/// <summary>
		/// Disposes the SqlTransaction
		/// </summary>
		public void Dispose() {
			mTransaction.Dispose();
			if (!mHasEnded)
				OnRolledBack(this, new EventArgs());
			mHasEnded = true;
		}
		/// <summary>
		/// Raises the Committed event
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">An EventArgs object containing event data</param>
		protected void OnCommitted(object sender, EventArgs e) {
			if (Committed != null)
				Committed(sender, e);
			Committed = null;
		}
		/// <summary>
		/// Raises the RolledBack event
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">An EventArgs object containing event data</param>
		protected void OnRolledBack(object sender, EventArgs e) {
			if (RolledBack != null)
				RolledBack(sender, e);
			RolledBack = null;
		}
	}
