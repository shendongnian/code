	// file 'InfoProvider.cs' in C:\TEMP\PshWindow
	using System;
	using System.Threading;
	using System.Windows.Forms;
	namespace PshWindow
	{
		public sealed class InfoProvider : IDisposable
		{
			public void Dispose()
			{
				GC.SuppressFinalize(this);
				lock (this._sync)
				{
					if (!this._disposed)
					{
						this._disposed = true;
						if (null != this._worker)
						{
							if (null != this._form)
							{
								this._form.Invoke(new Action(() => this._form.Close()));
							}
							this._worker.Join();
							this._form = null;
							this._worker = null;
						}
					}
				}
			}
			public void ShowMessage(string msg)
			{
				lock (this._sync)
				{
					// make sure worker is up and running
					if (this._disposed) { throw new ObjectDisposedException("InfoProvider"); }
					if (null == this._worker)
					{
						this._worker = new Thread(() => (this._form = new MyForm(this._sync)).ShowDialog()) { IsBackground = true };
						this._worker.Start();
						while (this._form == null || !this._form.Created)
						{
							Monitor.Wait(this._sync);
						}
					}
					// update the text
					this._form.Invoke(new Action(delegate
					{
						this._form.Text = msg;
						this._form.Activate();
					}));
				}
			}
			private bool _disposed;
			private Form _form;
			private Thread _worker;
			private readonly object _sync = new object();
		}
	}
