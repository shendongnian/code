            List<Item> items;
            public void LoadJsonAndReadToXML()
            {
                using (StreamReader r = new StreamReader(@"E:\Json\overiddenhotelranks.json"))
                {
                    string json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<Item>>(json);
                    ReadToXML();
                }
            }
