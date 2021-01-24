    protected void btn_Geht_Click(object sender, EventArgs e)
    {
        string sPath = @"C:\VSTO\Projects\Zeiterfassung\Zeiterfassung\obj\Debug\Zeiten.txt";
        cZeile Geht = null; // no point newing up an object since you are about to assign to it below
        using (StreamReader sr = new StreamReader(sPath))
        {
            Geht = cZeiterfassung.GetZeileObjectFromZeileString(sr.ReadLine(), ";");
            Geht.Geht = DateTime.Now.ToString("hh:mm");
            Geht.dtGeht = DateTime.Now;
        }
        File.WriteAllText(sPath, string.Format("{0:yyyyMMdd_hhmm};{1};{2:dd.MM.yyyy};{3:hh:mm};{4:hh:mm}", Geht.ID, Geht.User, Geht.Datum, Geht.Kommt, Geht.Geht));
    }
