            private System.Windows.Forms.BindingSource bsContractors;
			private System.Windows.Forms.ComboBox cmbContract_Contractors;
			bsContractors = new System.Windows.Forms.BindingSource(this.components);
			bsContractors.DataSource = typeof(Contractor);
			bsContractors.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.bsBindingComplete);
			var binding = new System.Windows.Forms.Binding("SelectedValue", this.bsProject, "ContractorId", true);	//changed
			binding.FormattingEnabled = true;	//changed
			cmbContract_Contractors.DataBindings.Add(binding);	//changed
			cmbContract_Contractors.DataSource = this.bsContractors;
