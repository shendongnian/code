    if (typen.SelectedItem == null)
    {
        MessageBox.Show("Error - Please enter xyz");
    }
    else
    {
        if (typen.SelectedItem.ToString() == "Mountenbike")
        {
            mb = new Mountenbike(artikelNr, name, ekPreis, vkPreis);
            mbCounter++;
            MessageBox.Show("Fertig");
        }
        else if (typen.SelectedItem.ToString() == "Rennrad")
        {
            rr = new Rennrad(artikelNr, name, ekPreis, vkPreis);
            rrCounter++;
            MessageBox.Show("Fertig");
        }
        else if (typen.SelectedItem.ToString() == "Faltrad")
        {
            fr = new Faltrad(artikelNr, name, ekPreis, vkPreis);
            frCounter++;
            MessageBox.Show("Fertig");
        }
    }
