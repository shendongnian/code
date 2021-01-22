    [Test]
        public void TestGetVersion()
        {
            //string version = "";
            byte[] version = new byte[8];
            LatLonUtils.GetGeoConvertVersion(version);
            char[] versionChars = System.Text.Encoding.ASCII.GetChars(version);
            
            string versionString = new string(versionChars);
        }
