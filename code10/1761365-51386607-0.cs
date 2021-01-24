    public void SaglasnostZaAnesteziju (string pathF, string newfile, PacijentVlasnik pv)
    {
            var str = System.IO.File.CreateText(newfile);
            str.Close();
            System.IO.File.Copy(pathF, newfile, true);
            PdfReader pdfReader = new PdfReader(pathF);
            PdfStamper stamper = new PdfStamper(pdfReader, new FileStream(newfile, FileMode.OpenOrCreate));
            
            AcroFields fields = stamper.AcroFields;
            
            fields.SetField("TextField1[0]", pv.vlasnikImeIPreizme);
            fields.SetField("TextField1[1]", pv.vlasnikAdr);
            fields.SetField("TextField1[2]", pv.vlasnikTel);
            fields.SetField("TextField1[8]", pv.pacijentVrsta);
            fields.SetField("TextField4[0]", pv.pacijentRasa);
            fields.SetField("TextField1[9]", pv.pacijentPol);
            fields.SetField("TextField1[3]", pv.pacijentImeZ);
            fields.SetField("TextField1[5]", pv.pacijentDatumRodj);
            fields.SetField("TextField1[4]", pv.brcip);
            
            stamper.Close();
        }
