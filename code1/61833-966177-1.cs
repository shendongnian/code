    private void AddressForm_FormClosing(object sender, FormClosingEventArgs e)
    {
    	if(!m_addressPresenter.ViewRequestingClose())
    		e.Cancel = true;
    }
    
    private void CancelButton_Click(object sender, FormClosingEventArgs e)
    {
    	if(m_addressPresenter.ViewRequestingClose())
    		this.Close();
    }
