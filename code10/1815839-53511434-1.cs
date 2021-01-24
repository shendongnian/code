    private void WriteToBinFile(List<MyClass> myObjList, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        using (BinaryWriter bw = new BinaryWriter(fs))
        {
            foreach (MyClass myObj in myObjList)
            {
                bw.Write(JsonConvert.SerializeObject(myObj));
            }
        }
    }
    private List<MyClass> ReadFromBinFile(string filePath)
    {
        List<MyClass> myObjList = new List<MyClass>();
        using (FileStream fs = new FileStream(filePath, FileAccess.Read))
        using (BinaryReader br = new BinaryReader(fs))
        {
            while (fs.Length != fs.Position) // This will throw an exception for non-seekable streams (stream.CanSeek == false), but filestreams are seekable so it's OK here
            {
				myObjList.Add(JsonConvert.DeserializeObject<MyClass>(br.ReadString()));
            }
        }
        return myObjList;
    }
	
