	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tasks")]
	public partial class Task : INotifyPropertyChanging, INotifyPropertyChanged
	{
		private int _TaskId;
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int TaskId
		{
			get
			{
				return this._TaskId;
			}
			set
			{
				if ((this._TaskId != value))
				{
					this.OnTaskIdChanging(value);
					this.SendPropertyChanging();
					this._TaskId = value;
					this.SendPropertyChanged("TaskId");
					this.OnTaskIdChanged();
				}
			}
		}
    }
