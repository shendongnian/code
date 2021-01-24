    private void SaveAsBinary()
            {
                Dictionary<DateTime, int> myData = new Dictionary<DateTime, int>();
                myData.Add(new DateTime(2018,4,11), 24);
                myData.Add(new DateTime(2017,4,13), 32);
                myData.Add(new DateTime(2016,7,22), 37);
                BinaryFormatter bf = new BinaryFormatter();
               
                using (Stream fs = new FileStream("myData.dat", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    bf.Serialize(fs, myData);
                }
                MessageBox.Show("Saved Dictionary as binary");
            }
            private void RetrieveDictionay()
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (Stream fs = File.OpenRead("myData.dat"))
                {
                    Dictionary<DateTime,int> myDataFromDisk = (Dictionary<DateTime,int>)bf.Deserialize(fs);
    
                    foreach (KeyValuePair<DateTime,int> kv in myDataFromDisk)
                    {
                        Debug.Print($"Key = {kv.Key}, Value = {kv.Value}");
                    }
                }
            }
