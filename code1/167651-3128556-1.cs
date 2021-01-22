            var fs = File.Open(@"C:\Temp\SNB-RSS.xml", FileMode.Open);
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(fs);
            }
            finally
            {
                if (reader== null)
                {
                    fs.Dispose();
                }
            }
            if (reader != null)
            {
                using (reader)
                {
                    /* Some other code */
                }
            }
