    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        if (Notlar.Length > 0)
        {
            foreach (int s in Notlar)
            {
                sb.Append(" ");
                sb.Append(s.ToString());
            }
        }
     return $"Grup Kodu : {this.GrupKodu} Grup Adı : {this.GrupAd} Notlar : {sb.ToString()}";
     }
