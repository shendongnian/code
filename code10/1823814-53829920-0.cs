    public void CreateListOfObjects()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "history.txt");
            var content = File.ReadAllText(fileName);
            var itemList = JsonConvert.DeserializeObject<List<string>>(content);
            foreach(var item in itemList)
            {
                listView2.Items.Add(item);
            }
        }
