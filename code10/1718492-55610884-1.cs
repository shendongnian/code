    public void getScheduleData(Document doc)
    {
        FilteredElementCollector collector = new FilteredElementCollector(doc);
        IList<Element> collection = collector.OfClass(typeof(ViewSchedule)).ToElements();
        String prompt = "ScheduleData :";
        prompt += Environment.NewLine;
        foreach (Element e in collection)
        {
            ViewSchedule viewSchedule = e as ViewSchedule;
            TableData table = viewSchedule.GetTableData();
            TableSectionData section = table.GetSectionData(SectionType.Body);
            int nRows = section.NumberOfRows;
            int nColumns = section.NumberOfColumns;
            if (nRows > 1)
            {
                //valueData.Add(viewSchedule.Name);
                List<List<string>> scheduleData = new List<List<string>>();
                for (int i = 0; i < nRows; i++)
                {
                    List<string> rowData = new List<string>();
                    for (int j = 0; j < nColumns; j++)
                    {
                        rowData.Add(viewSchedule.GetCellText(SectionType.Body, i, j));
                    }
                    scheduleData.Add(rowData);
                }
                List<string> columnData = scheduleData[0];
                scheduleData.RemoveAt(0);
                DataMapping(columnData, scheduleData);
            }
        }
    }
    public static void DataMapping(List<string> keyData, List<List<string>>valueData)
    {
        List<Dictionary<string, string>> items= new List<Dictionary<string, string>>();
        string prompt = "Key/Value";
        prompt += Environment.NewLine;
        foreach (List<string> list in valueData)
        {
            for (int key=0, value =0 ; key< keyData.Count && value< list.Count; key++,value++)
            {
                Dictionary<string, string> newItem = new Dictionary<string, string>();
                string k = keyData[key];
                string v = list[value];
                newItem.Add(k, v);
                items.Add(newItem);
            }
        }
        foreach (Dictionary<string, string> item in items)
        {
            foreach (KeyValuePair<string, string> kvp in item)
            {
                prompt += "Key: " + kvp.Key + ",Value: " + kvp.Value;
                prompt += Environment.NewLine;
            }
        }
        Autodesk.Revit.UI.TaskDialog.Show("Revit", prompt);
    }
