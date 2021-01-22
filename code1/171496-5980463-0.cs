    InventorySystemDomainContext context = new InventorySystemDomainContext();
    
    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
    	Cigarette c = cboCigarette.SelectedItem as Cigarette;
    	c.Active = false;
    
    	SubmitOperation so = context.SubmitChanges(OnCigaretteSaved, null);
    }
    
    private void OnCigaretteSaved(SubmitOperation so)
    {
    	context.Cigarettes.Detach(context.Cigarettes.Where(item => item.Active == false).First());
    }
    
    private void LoadComboBox()
    {
    	cboCigarettes.DataSource = null;
    	cboCigarettes.DataSource = context.Cigarettes;
    	context.Load(context.GetCigarettesQuery());
    }
