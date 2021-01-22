        private RadComboBox cmbShowTimeAs = null; 
 
        public CustomAppointmentEditDialog() 
        { 
            InitializeComponent(); 
 
            this.cmbShowTimeAs = this.Controls["cmbShowTimeAs"] as RadComboBox; 
        } 
 
        private void chkConfirmed_ToggleStateChanged(object sender, StateChangedEventArgs args) 
        { 
            this.cmbShowTimeAs.SelectedValue = (args.ToggleState == ToggleState.On) ? 
                (int)AppointmentStatus.Busy : (int)AppointmentStatus.Tentative; 
        } 
    } 
