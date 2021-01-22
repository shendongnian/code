        if (dlg == DialogResult.Yes)
        {
            saveDepart(); // Metod save depart
            e.Cancel = false;
        }
        if(dlg ==DialogResult.No)
        {
            e.Cancel = false;
        }
