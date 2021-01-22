       using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    using SomeNameSpace.Utilities.UI;
    using SomeNameSpace.Utilities.Validation;
    
    namespace Management.UI
    {
    	public partial class ManualControl : UserControl, IManualRaffleView
    	{
    
    
    		private ManualPresenter _presenter;
    
    		public ManualControl()
    		{
    			InitializeComponent();
    		}
    
    
    		[Browsable(false)]
    		public ManualPresenter Presenter
    		{
    			get
    			{
    				return _presenter;
    			}
    			set
    			{
    				_presenter = value;
    				if(_presenter != null)
    				{
    					_manualPresenterBindingSource.DataSource = _presenter;
    					_ListBindingSource.DataSource = _presenter;
    					_ListBindingSource.DataMember = "Something";
    					_KindListBindingSource.DataSource = _presenter;
    					_KindListBindingSource.DataMember = "SomethingElse";
    					
    					_presenter.CloseView += new Action(CloseMe);
    					_presenter.VerifyingCancel += new Func<bool>(VerifyingCancel);
    					_presenter.Showing += new Action(ShowMe);
    					_presenter.Synchronizer = this;
    				}
    			}
    		}
    
    
    		void CloseMe()
    		{
    			this.Enabled = false;
    		}
    
    		private void ManualRaffleForm_FormClosing(object sender, FormClosingEventArgs e)
    		{
    			e.Cancel = false;
    		}
    
    		private void ShowMe()
    		{
    			this.Enabled = true;
    		}
    
    		bool VerifyingCancel()
    		{
    			return MessageBox.Show("Cancel?", Notifier.ApplicationName,
    				MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    				MessageBoxDefaultButton.Button2) == DialogResult.Yes;
    		}
    
    		private void _cancelButton_Click(object sender, EventArgs e)
    		{
    			Presenter.HandleCancel();
    		}
    
    		private void _initiateButton_Click(object sender, EventArgs e)
    		{
    			Presenter.HandleInitiate();
    		}
    
    		private void _saveButton_Click(object sender, EventArgs e)
    		{
    			if(Presenter.Error == true.ToString())
    				Presenter.HandleDone();
    			else
    				_manualPresenterBindingSource.ResetBindings(false);
    		}
    
    	}
    }
