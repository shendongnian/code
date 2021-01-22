    [Table(Name="dbo.SCMessages")]
	[DataContract()]
	public partial class SCMessage : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MessageID;
		
		private string _MessageAuthor;
		
		private string _MessageText;
		
		private System.DateTime _MessageDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMessageIDChanging(int value);
    partial void OnMessageIDChanged();
    partial void OnMessageAuthorChanging(string value);
    partial void OnMessageAuthorChanged();
    partial void OnMessageTextChanging(string value);
    partial void OnMessageTextChanged();
    partial void OnMessageDateChanging(System.DateTime value);
    partial void OnMessageDateChanged();
    #endregion
		
		public SCMessage()
		{
			this.Initialize();
		}
		
		[Column(Storage="_MessageID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		[DataMember(Order=1)]
		public int MessageID
		{
			get
			{
				return this._MessageID;
			}
			set
			{
				if ((this._MessageID != value))
				{
					this.OnMessageIDChanging(value);
					this.SendPropertyChanging();
					this._MessageID = value;
					this.SendPropertyChanged("MessageID");
					this.OnMessageIDChanged();
				}
			}
		}
