	public class ControlParameter : Parameter
	{
		public string ControlID { get; set; } //stored in ViewState
		public string PropertyName { get; set; } //stored in ViewState
		protected override object Evaluate(HttpContext context, Control owner)
		{
			Control sourceControl = DataBoundControlHelper.FindControl(owner, this.ControlID);
			//evaluate C.C1 using reflection
			return DataBinder.Eval(sourceControl, this.PropertyName);
		}
		internal void UpdateValue(HttpContext context, Control owner)
		{
			//PostBack or not, read stored value (on initial load it is empty)
			object storedValue = this.ViewState["ParameterValue"];
			//Get the actual value for this parameter from C.C1
			object actualValue = this.Evaluate(context, owner);
			//Store received value
			this.ViewState["ParameterValue"] = actualValue;
			//Fire a change event if necessary
			if ((actualValue == null && storedValue != null)
			 || (actualValue != null && actualValue != storedValue))
				this.OnParameterChanged();
		}
	}
	public class SqlDataSource : DataSourceControl
	{
		//fired by OnLoadComplete
		private void LoadCompleteEventHandler(object sender, EventArgs e)
		{
			//UpdateValues simply calls the UpdateValue for each parameter
			this.SelectParameters.UpdateValues(this.Context, this);
			this.FilterParameters.UpdateValues(this.Context, this);
		}
	}
	public class SqlDataSourceView : DataSourceView, IStateManager
	{
		private SqlDataSource _owner;
		//this method gets called by DataBind (including on PreRenderRecursiveInternal)
		protected internal override IEnumerable ExecuteSelect(DataSourceSelectArguments arguments)
		{
			DbConnection connection = this._owner.CreateConnection(this._owner.ConnectionString);
			DbCommand command = this._owner.CreateCommand(this.SelectCommand, connection);
			//This is where ControlParameter will read C.C1 values again.
			//Except this time, C.C1 will be already populated by its own DataBind
			this.InitializeParameters(command, this.SelectParameters, null);
			command.CommandType = GetCommandType(this.SelectCommandType);
			SqlDataSourceSelectingEventArgs e = new SqlDataSourceSelectingEventArgs(command, arguments);
		
			this.OnSelecting(e);
			
			if (e.Cancel)
				return null;
			//...get data from DB
			this.OnSelected(new SqlDataSourceStatusEventArgs(command, affectedRows, null));
			//return data (IEnumerable or DataView)
		}
		private void InitializeParameters(DbCommand command, ParameterCollection parameters, IDictionary exclusionList)
		{
			//build exlusions list
			//...
			//Retrieve parameter values (i.e. from C.C1 for the ControlParameter)
			IOrderedDictionary values = parameters.GetValues(this._context, this._owner);
			
			//build command's Parameters collection using commandParameters and retrieved values
			//...
		}
	}
