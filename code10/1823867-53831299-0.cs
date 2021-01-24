    void PrintPoint(Vector3 vector)
    {
       //path of file
      string path = Application.dataPath + "/Player.txt";
      //create file if nonexistent
      if(!File.Exists(path))
      {
        File.WriteAllText(path, "The player blob visited these random coordinates: \n\n");
      }
      File.AppendAllText(path, "(" + vector.x + ", " + vector.y + ", " + vector.z + ")\n\n");
    }
