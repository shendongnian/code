            var yourtabs = tabControlFEPages.Controls.OfType<TabPage>().Where(tab => 
            tab.Text.Equals(cmbFEEdytujKarteWybierzKarte.Text)).ToList(); 
            var index = tabControlFEPages.TabPages.IndexOf(yourtabs[0]);
            if (!string.IsNullOrEmpty(txtFEEdytujKarteNowaNazwa.Text))
                tabControlFEPages.TabPages[index].Text = 
             txtFEEdytujKarteNowaNazwa.Text.ToString();
            
