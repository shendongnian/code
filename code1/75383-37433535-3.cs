    public interface ILogBoxViewModel
	{
		void CmdAppend(string toAppend);
		void CmdClear();
		bool AttachedPropertyClear { get; set; }
		string AttachedPropertyAppend { get; set; }
	}
	[Export(typeof(ILogBoxViewModel))]
	public class LogBoxViewModel : ILogBoxViewModel, INotifyPropertyChanged
	{
		private readonly ILog _log = LogManager.GetLogger<LogBoxViewModel>();
		private bool _attachedPropertyClear;
		private string _attachedPropertyAppend;
		public void CmdAppend(string toAppend)
		{
			string toLog = $"{DateTime.Now:HH:mm:ss} - {toAppend}\n";
			// Attached properties only fire on a change. This means it will still work if we publish the same message twice.
			AttachedPropertyAppend = "";
			AttachedPropertyAppend = toLog;
			_log.Info($"Appended to log box: {toAppend}.");
		}
		public void CmdClear()
		{
			AttachedPropertyClear = false;
			AttachedPropertyClear = true;
			_log.Info($"Cleared the GUI log box.");
		}
		public bool AttachedPropertyClear
		{
			get { return _attachedPropertyClear; }
			set { _attachedPropertyClear = value; OnPropertyChanged(); }
		}
		public string AttachedPropertyAppend
		{
			get { return _attachedPropertyAppend; }
			set { _attachedPropertyAppend = value; OnPropertyChanged(); }
		}
		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion
	}
