    private void set2ControlTopanel(control f) {
        
        try {
            p2Form = f;
            p2Form.Dock = DockStyle.Fill;
            p2Form.Show();
            panelTop.Controls.Add(p2Form);
            p2Form.BringToFront();
        }
        catch (Exception ex) {
            MsgBox(ex.Message);
        }
        
    }
