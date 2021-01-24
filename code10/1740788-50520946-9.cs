        private void FrmSaveCSV_Load(object sender, EventArgs e)
        {
            LoadStaus();
        }
        private void FrmSaveCSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveStatus();
        }
        private void LoadStaus()
        {
            this.Checkbox1.Checked = m_statusClass.Chkbox1Checked;
            this.Checkbox2.Checked = m_statusClass.Chkbox2Checked;
            //same way load other controls
        }
        private void SaveStatus()
        {
            m_statusClass.Chkbox1Checked = this.Checkbox1.Checked;
            m_statusClass.Chkbox2Checked = this.Checkbox2.Checked;
        }
 
