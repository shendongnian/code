    private void WriteToFile(List<MyClass> myObjList, string filePath)
    {
        using (StreamWriter sw = File.CreateText(filePath))
        {
            foreach (MyClass myObj in myObjList)
            {
                sw.Write(JsonConvert.SerializeObject(myObj, Newtonsoft.Json.Formatting.None));
            }
        }
    }
    private List<MyClass> ReadFromFile(string filePath)
    {
        List<MyClass> myObjList = new List<MyClass>();
        using (StreamReader sr = File.OpenText(filePath))
        {
            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                myObjList.Add(JsonConvert.DeserializeObject<MyClass>(line));
            }
        }
        return myObjList;
    }
	
