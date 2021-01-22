        String[] formats = ucBrandLogoFileUploadControl.Split('|');
        String output = "Allowed formats are ";
        for (int i = 0; i < formats.Length; i++)
        {
            if (i > 0)
            {
                if (i < formats.Length - 1) { output += ", "; }
                else { output += " and "; }
            }
            output += "\"" + formats[i] + "\"";
        }
