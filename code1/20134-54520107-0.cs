    List<dynamic> sampleListOfRecords = new List<dynamic>();
    Queue<dynamic> recordQueue = new Queue<dynamic>();
    //I add data to queue from a sample list
    foreach(dynamic r in sampleListOfRecords)
    {
         recordQueue.Enqueue(r);
    }
                    
    //Serialize
    File.WriteAllText("queue.json",
         JsonConvert.SerializeObject(recordQueue.ToList(), Formatting.Indented));
    //Deserialize
    List<dynamic> data = 
         JsonConvert.DeserializeObject<List<dynamic>>(File.ReadAllText("queue.json"));
