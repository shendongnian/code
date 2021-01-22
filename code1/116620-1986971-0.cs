        public static void MyConfigLoad()
        {
            if (!File.Exists(myConfigFileName))
            {
                return;
            }
           
            XmlSerializer mySerializer = new XmlSerializer(myConfigClass.GetType());
            using (StreamReader myXmlReader = new StreamReader(myConfigFileName))
            {
                try
                {
                    myConfigClass = (MyConfigClass)mySerializer.Deserialize(myXmlReader);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка сериализации MyConfigLoad\n" + e.ToString());
                }
            }
        }
        public static void MyConfigSave()
        {
            XmlSerializer mySerializer = new XmlSerializer(myConfigClass.GetType());
            using (StreamWriter myXmlWriter = new StreamWriter(myConfigFileName))
            {
                try
                {
                    mySerializer.Serialize(myXmlWriter, myConfigClass);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка сериализации MyConfigSave\n" + e.ToString());
                }
            }
        }
