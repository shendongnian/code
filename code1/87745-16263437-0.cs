        private void ShowForm(Type typeofForm, string sCaption)
        {
            Form fOpen = GetOpenForm(typeofForm);
            Form fNew = fOpen;
            if (fNew == null)
                fNew = (Form)CreateNewInstanceOfType(typeofForm);
            else
                if (fNew.IsDisposed)
                    fNew = (Form)CreateNewInstanceOfType(typeofForm);
            if (fOpen == null)
            {
                fNew.Text = sCaption;
                fNew.ControlBox = true;
                fNew.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                fNew.MaximizeBox = false;
                fNew.MinimizeBox = false;
                // for MdiParent
                //if (f1.MdiParent == null)
                //    f1.MdiParent = CProject.mFMain;
                fNew.StartPosition = FormStartPosition.Manual;
                fNew.Left = 0;
                fNew.Top = 0;
                ShowMsg("Ready");
            }
            fNew.Show();
            fNew.Focus();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FAboutBox), "About");
        }
        private Form GetOpenForm(Type typeofForm)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form f1 in fc)
                if (f1.GetType() == typeofForm)
                    return f1;
            return null;
        }
        private object CreateNewInstanceOfType(Type typeofAny)
        {
            return Activator.CreateInstance(typeofAny);
        }
        public void ShowMsg(string sMsg)
        {
            lblStatus.Text = sMsg;
            if (lblStatus.ForeColor != SystemColors.ControlText)
                lblStatus.ForeColor = SystemColors.ControlText;
        }
