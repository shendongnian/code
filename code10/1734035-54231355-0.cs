        private const int CR_PROP_TEMPLATES = 0x0000001D;
        private const int PROPTYPE_STRING = 0x00000004;
        public void GetTemplates(string CAServer)
        {
            try
            {
                var objCertRequest = new CCertRequest();
                Regex regex = new Regex(@"([A-Za-z]+)");
                string templateString = objCertRequest.GetCAProperty(CAServer, CR_PROP_TEMPLATES, 0, PROPTYPE_STRING, 0);
                string[] templates = Regex.Split(templateString, @"\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
