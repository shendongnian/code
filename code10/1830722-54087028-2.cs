        public Reporter(String filePath, FileType type)
                    {
                        PropRnW = new PropertyFileReader(filePath, type);
                        this.Property1 = PropRnW.m_reporter.Property1;
                        this.Property2 = PropRnW.m_reporter.Property2;
                    }   
        
        class PropertyFileReader
    {
        public Reporter m_reporter {get; set;}
    
        public PropertyFileReader(String filePath, FileType type)
                    {
                        OriginalPath = filePath;
                        Type = type;
                        this.Read();
                    } 
        
        private void Read()
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(SavePath, FileMode.Open, FileAccess.Read);
        
                m_reporter = (Reporter)formatter.Deserialize(stream);
                stream.Close();
            }
    };
