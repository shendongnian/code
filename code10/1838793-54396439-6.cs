      public EditingsViewModel()
        {
              ComboBoxModel = new Model();
            //Xml Path
            string xmlpath = @"D:\MyDocument.xml";
            var doc = new XmlDocument();
            doc.Load(xmlpath);
            XmlNode xmlNode = doc.SelectSingleNode(@"/MYEDITINGS/Group/EditingsName/@value");           
            //Binding the Color to the Color Property
            var observableColors = new System.Collections.ObjectModel.ObservableCollection<string>() { "red","yellow","green"};
            ComboBoxModel.Color = observableColors;
            //Assign the Default vlaue from the Xml Document 
            SelectedColor = xmlNode.Value;
        }
