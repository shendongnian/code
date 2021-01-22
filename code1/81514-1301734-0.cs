     public bool SavePlant(Plant plantData)
        {
            DataAcccess _newDataAccess = new DataAcccess();
            XElement _xmlEntity = _newDataAccess.LoadXMLFile("EntityData");
            //Validation code removed to make example easier to follow.
            XElement _xmlPlantData = new XElement ("Plant",
                new XElement("Name", plantData.Name),
                new XElement("Address", plantData.Address),
                new XElement("City", plantData.City),
                new XElement("State", plantData.State),
                new XElement("Zip", plantData.Zip),
                new XElement("Phone", plantData.Phone),
                new XElement("WorkDays", plantData.WorkDays),
                new XElement("WorkHours", plantData.WorkHours),
                new XElement("EfficiencyRate", plantData.EfficiencyRate));
            XElement _xmlTemp = _xmlEntity.Descendants("Company").First(el => (string)el.Element("Name").Value == plantData.ParentCompany);
            _xmlTemp.Element("Plants").Add(_xmlPlantData);
           
            //Save the tree in the EntityData.xml file and return a bool for the results
            return _newDataAccess.SaveXMLData("EntityData", _xmlEntity);
        } 
        
    }
