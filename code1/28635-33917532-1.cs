    public class CConfigMng
    {
        private string m_sConfigFileName = System.IO.Path.GetFileNameWithoutExtension(System.Windows.Forms.Application.ExecutablePath) + ".xml";
        private CConfigDO m_oConfig = new CConfigDO();
        public CConfigDO Config
        {
            get { return m_oConfig; }
            set { m_oConfig = value; }
        }
        // Load configfile
        public void LoadConfig()
        {
            if (System.IO.File.Exists(m_sConfigFileName))
            {
                System.IO.StreamReader srReader = System.IO.File.OpenText(m_sConfigFileName);
                Type tType = m_oConfig.GetType();
                System.Xml.Serialization.XmlSerializer xsSerializer = new System.Xml.Serialization.XmlSerializer(tType);
                object oData = xsSerializer.Deserialize(srReader);
                m_oConfig = (CConfigDO)oData;
                srReader.Close();
            }
        }
        // Save configfile
        public void SaveConfig()
        {
            System.IO.StreamWriter swWriter = System.IO.File.CreateText(m_sConfigFileName);
            Type tType = m_oConfig.GetType();
            if (tType.IsSerializable)
            {
                System.Xml.Serialization.XmlSerializer xsSerializer = new System.Xml.Serialization.XmlSerializer(tType);
                xsSerializer.Serialize(swWriter, m_oConfig);
                swWriter.Close();
            }
        }
    }
