    private DataGridViewColumns[] PreProducitonColumns {get;set;}
    private DataGridViewColumns[] ProductionColumns {get;set;}
    private DataGridViewColumns[] ContractsColumns {get;set;}
    
    private void Form_Load()
    {
        this.PreProducitonColumns = searchSettings.GetPreProductionColumns();
        this.ProductionColumns = searchSettings.GetProductionColumns();
        this.ContractsColumns = searchSettings.GetContractsColumns();
    }
    
    private void rbContracts_CheckedChanged(object sender, EventArgs e) 
    { 
        dgvContracts.Columns.Clear(); 
        if (((RadioButton)sender).Checked == true) 
        { 
            if (sender == rbPreProduction) 
            { 
                dgvContracts.Columns.AddRange(PreProducitonColumns); 
                this.contractsBindingSource.DataMember = "Preproduction"; 
                this.preproductionTableAdapter.Fill(this.searchDialogDataSet.Preproduction); 
            } 
            else if (sender == rbProduction) 
            { 
                dgvContracts.Columns.AddRange(ProductionColumns); 
                this.contractsBindingSource.DataMember = "Production"; 
                this.productionTableAdapter.Fill(this.searchDialogDataSet.Production); 
     
            } 
            else if (sender == rbContracts) 
            { 
                dgvContracts.Columns.AddRange(ContractsColumns); 
                this.contractsBindingSource.DataMember = "Contracts"; 
                this.contractsTableAdapter.Fill(this.searchDialogDataSet.Contracts); 
            } 
        } 
    } 
