      public EditingsViewModel()
        {
               ComboBoxModel = new EditingModel();
            //Xml Path
            string xmlpath = @"D:\MyDocument.xml";
            var doc = new XmlDocument();
            doc.Load(xmlpath);
            XmlNode colorNode = doc.SelectSingleNode(@"/MYEDITINGS/Group/EditingsName[@name = 'COLOR']/@value");
            XmlNode shapesNode = doc.SelectSingleNode(@"/MYEDITINGS/Group/EditingsName[@name = 'SHAPES']/@value");
            XmlNode sizeNode = doc.SelectSingleNode(@"/MYEDITINGS/Group/EditingsName[@name = 'SIZE']/@value");
            XmlNode filePathNode = doc.SelectSingleNode(@"/MYEDITINGS/Group/EditingsName[@name = 'FILE PATH']/@value");
            //Binding the Color to the Color Property
            var observableColors = new System.Collections.ObjectModel.ObservableCollection<string>() { "red","yellow","green"};
            ComboBoxModel.Color = observableColors;
            //Binding the Shapes to the Shape Property
            var observableShapes = new System.Collections.ObjectModel.ObservableCollection<string>() { "circle", "Triangle", "Rectangle" };
            ComboBoxModel.Shapes = observableShapes;
            //Binding the Size to the Size Property
            var observableSize = new System.Collections.ObjectModel.ObservableCollection<string>() { "medium", "high", "low" };
            ComboBoxModel.Size = observableSize;
           
            //Assign the Color Default vlaue from the Xml Document 
            SelectedColor = colorNode.Value;
            //Assign the Shape Default vlaue from the Xml Document 
            SelectedShapes = shapesNode.Value;
            //Assign the Size  Default vlaue from the Xml Document 
            SelectedSize = sizeNode.Value;
            //Assign the FilePath Default vlaue from the Xml Document 
            FolderPath = filePathNode.Value;
        }
