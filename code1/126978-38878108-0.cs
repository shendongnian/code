    using System.ComponentModel.Design;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Data;
    using System;
    
    
    public class BindingSourceExIsDirty : System.Windows.Forms.BindingSource, INotifyPropertyChanged
    {
    
    	#region "DECLARATIONS AND PROPERTIES"
    
    	private string _displayMember;
    	private DataTable _dataTable;
    	private DataSet _dataSet;
    	private BindingSource _parentBindingSource;
    	private System.Windows.Forms.Form _form;
    	private System.Windows.Forms.Control _usercontrol;
    
    
    
    
    	private bool _isCurrentDirtyFlag = false;
    	public bool IsCurrentDirty {
    		get { return _isCurrentDirtyFlag; }
    		set {
    			if (_isCurrentDirtyFlag != value) {
    				_isCurrentDirtyFlag = value;
    				this.OnPropertyChanged(value.ToString());
    				//call the event when flag is set
    				if (value == true) {
    					OnCurrentIsDirty(new EventArgs());
    
    				}
    			}
    		}
    	}
    
    
    	private string _objectSource;
    	public string ObjectSource {
    		get { return _objectSource; }
    		set {
    			_objectSource = value;
    			this.OnPropertyChanged(value);
    		}
    	}
    
    
    private bool _autoSaveFlag;
    
    public bool AutoSave {
    	get { return _autoSaveFlag; }
    	set {
    		_autoSaveFlag = value;
    		this.OnPropertyChanged(value.ToString());
    	}
    } 
    
    	#endregion
    
    	#region "EVENTS"
    
    
    	//Current Is Dirty Event
    	public event CurrentIsDirtyEventHandler CurrentIsDirty;
    
    	// Delegate declaration.
    	public delegate void CurrentIsDirtyEventHandler(object sender, EventArgs e);
    
    	protected virtual void OnCurrentIsDirty(EventArgs e)
    	{
    		if (CurrentIsDirty != null) {
    			CurrentIsDirty(this, e);
    		}
    	}
    
    	//PropertyChanged Event 
    //	public event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged;
    
    	public event PropertyChangedEventHandler PropertyChanged;
    	protected virtual void OnPropertyChanged(string info)
    	{
    		
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }		
    		
    	}
    
    
    
    	#endregion
    
    	#region "METHODS"
    
    
    
    	private void _BindingComplete(System.Object sender, System.Windows.Forms.BindingCompleteEventArgs e)
    	{
    
    		if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate) {
    
    			if (e.BindingCompleteState == BindingCompleteState.Success & !e.Binding.Control.BindingContext.IsReadOnly) {
    				//Make sure the data source value is refreshed (fixes problem mousing off control)
    				e.Binding.ReadValue();
    				//if not focused then not a user edit.
    				if (!e.Binding.Control.Focused)
    					return;
    
    				//check for the lookup type of combobox that changes position instead of value
    				if (e.Binding.Control as ComboBox != null) {
    					//if the combo box has the same data member table as the binding source, ignore it
    					if (((ComboBox)e.Binding.Control).DataSource != null) {
    						if (((ComboBox)e.Binding.Control).DataSource as BindingSource != null) {
    							if (((BindingSource)((ComboBox)e.Binding.Control).DataSource).DataMember == (this.DataMember)) {
    								return;
    							}
    
    						}
    
    					}
    				}
    				IsCurrentDirty = true;
    				//set the dirty flag because data was changed
    			}
    		}
    
    
    
    	}
    
    	private void _DataSourceChanged(System.Object sender, System.EventArgs e)
    	{
    		_parentBindingSource = null;
    		if (this.DataSource == null) {
    			_dataSet = null;
    		} else {
    			//get a reference to the dataset
    			BindingSource bsTest = this;
    			Type dsType = bsTest.DataSource.GetType();
    			//try to cast the data source as a binding source
    			while ((bsTest.DataSource as BindingSource != null)) {
    				//set the parent binding source reference
    				if (_parentBindingSource == null)
    					_parentBindingSource = bsTest;
    				//if cast was successful, walk up the chain until dataset is reached
    				bsTest = (BindingSource)bsTest.DataSource;
    			}
    			//since it is no longer a binding source, it must be a dataset or something else
    			if (bsTest.DataSource as DataSet == null) {
    				//Cast as dataset did not work
    
    				if (dsType.IsClass == false) {
    					throw new ApplicationException("Invalid Binding Source ");
    				} else {
    					_dataSet = null;
    
    				}
    
    			} else {
    				_dataSet = (DataSet)bsTest.DataSource;
    			}
    
    
    			//is there a data member - find the datatable
    			if (!string.IsNullOrEmpty(this.DataMember)) {
    				_DataMemberChanged(sender, e);
    			}
    			//CType(value.GetService(GetType(IDesignerHost)), IDesignerHost)
    			if (_form == null)
    				GetFormInstance();
    			if (_usercontrol == null)
    				GetUserControlInstance();
    		}
    	}
    
    	private void _DataMemberChanged(System.Object sender, System.EventArgs e)
    	{
    		if (string.IsNullOrEmpty(this.DataMember) | _dataSet == null) {
    			_dataTable = null;
    		} else {
    			//check to see if the Data Member is the name of a table in the dataset
    			if (_dataSet.Tables(this.DataMember) == null) {
    				//it must be a relationship instead of a table
    				System.Data.DataRelation rel = _dataSet.Relations(this.DataMember);
    				if ((rel != null)) {
    					_dataTable = rel.ChildTable;
    				} else {
    					throw new ApplicationException("Invalid Data Member");
    				}
    			} else {
    				_dataTable = _dataSet.Tables(this.DataMember);
    			}
    		}
    	}
    
    	public override System.ComponentModel.ISite Site {
    		get { return base.Site; }
    		set {
    			//runs at design time to initiate ContainerControl
    			base.Site = value;
    			if (value == null)
    				return;
    			// Requests an IDesignerHost service using Component.Site.GetService()
    			IDesignerHost service = (IDesignerHost)value.GetService(typeof(IDesignerHost));
    			if (service == null)
    				return;
    			if ((service.RootComponent as Form != null)) {
    				_form = (Form)service.RootComponent;
    			} else if ((service.RootComponent as UserControl != null)) {
    				_usercontrol = (UserControl)service.RootComponent;
    			}
    
    		}
    	}
    
    	public System.Windows.Forms.Form GetFormInstance()
    	{
    		if (_form == null & this.CurrencyManager.Bindings.Count > 0) {
    			_form = this.CurrencyManager.Bindings[0].Control.FindForm();
    
    		}
    		return _form;
    	}
    
    	/// <summary>
    	/// Returns the First Instance of the specified User Control
    	/// </summary>
    	/// <returns>System.Windows.Forms.Control</returns>
    	public System.Windows.Forms.Control GetUserControlInstance()
    	{
    		if (_usercontrol == null & this.CurrencyManager.Bindings.Count > 0) {
    			System.Windows.Forms.Control[] _uControls = null;
    			_uControls = this.CurrencyManager.Bindings[0].Control.FindForm().Controls.Find(this.Site.Name.ToString(), true);
    			_usercontrol = _uControls[0];
    
    		}
    		return _usercontrol;
    	}
    	public BindingSourceExIsDirty()
    	{
    		DataMemberChanged += _DataMemberChanged;
    		DataSourceChanged += _DataSourceChanged;
    		BindingComplete += _BindingComplete;
    	}
    
    // PositionChanged
    private override void _PositionChanged(object sender, EventArgs e)
    {
    	if (IsCurrentDirty) {
    		// IsAutoSavingEvent
    		if (AutoSave | MessageBox.Show(_msg, "Confirm Save", MessageBoxButtons.YesNo) == DialogResult.Yes) {
    			try {
    				//cast table as ITableUpdate to get the Update method
    				//  CType(_dataTable, ITableUpdate).Update()
    			} catch (Exception ex) {
    				MessageBox.Show(ex, "Position Changed Error");
    				// - needs to raise an event 
    			}
    		} else {
    			this.CancelEdit();
    			_dataTable.RejectChanges();
    		}
    		IsCurrentDirty = false;
          
    	}
     base(e);
    }
    
    
    	#endregion
    
    }
