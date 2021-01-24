    private string ConvertStrinToCamelStyle(string name)
        {
            string[] strName = name.Split(new string[] { " " }, StringSplitOptions.None);
            name = "";
            foreach (string strN in strName)
            {
                name += Char.ToUpperInvariant(strN[0]) + strN.Substring(1) + " ";
            }
            return name.Trim();
        }
