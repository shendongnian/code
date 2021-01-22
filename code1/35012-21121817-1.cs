    TabPage pageListe, pageDetay;
    bool isDetay = false;
    private void btnListeDetay_Click(object sender, EventArgs e)
    {
        if (isDetay)
        {
            isDetay = false;
            tc.TabPages.Remove(tpKayit);
            tc.TabPages.Insert(0,pageListe);
        }
        else
        {
            tc.TabPages.Remove(tpListe);
            tc.TabPages.Insert(0,pageDetay);
            isDetay = true;
        }
    }
