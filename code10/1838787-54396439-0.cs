      public ViewModel()
        {
            ComboBoxModel = new Model();
            //Xml Path
            string xmlpath = @"D:\MyDocument.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(MYDOCUMENT));
            MYDOCUMENT myDocument = null;
            //Read the xml file and Deserlize
            using (StreamReader reader = new StreamReader(xmlpath))
            {
                myDocument = (MYDOCUMENT)serializer.Deserialize(reader);
                reader.Close();
            }
            //Binding the Color to the Color Property
            var observableColors = new System.Collections.ObjectModel.ObservableCollection<string>() { "red","yellow","green"};
            ComboBoxModel.Color = observableColors;
            //Assign the Default vlaue from the Xml Document 
            SelectedColor = myDocument.Group.MydocumentName.Value;
        }
