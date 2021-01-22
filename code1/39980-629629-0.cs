            System.Text.Encoding iso_8859_1 = System.Text.Encoding.GetEncoding("iso-8859-1");
            System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;
	
            // Unicode string.
            string s_unicode = "abcéabc";
	
            // Convert to ISO-8859-1 bytes.
            byte[] isoBytes = iso_8859_1.GetBytes(s_unicode);
	
            // Convert to UTF-8.
            byte[] utf8Bytes = System.Text.Encoding.Convert(iso_8859_1, utf_8, isoBytes);
