            private static void button1_click()
        {
            var xmlSerializer = new XmlSerializer(typeof(eAction));
            using (var txtWriter = new StreamWriter(@"C:\temp\actionout.xml"))
            {
                var eActionItem = new eAction();
                xmlSerializer.Serialize(txtWriter, eActionItem);
            }
        }
