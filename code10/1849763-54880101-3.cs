    foreach(string file in FileNames)
    {
       Console.WriteLine(file);
       //FileStream s = new FileStream(file, FileMode.Open, FileAccess.Read);
       //IFormatter formatter = new BinaryFormatter();
       //ClientDataClass Client = (ClientDataClass)formatter.Deserialize(s);
       //s.Close();
       //ClientComboChoice.Items.Add(Client);
    }
