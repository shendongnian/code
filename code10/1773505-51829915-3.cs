    private gameObject GetObjectFromFile(Path, Id)
    {
       string[] text = new string[];
       if(File.Exists(path))
       {
       text = File.ReadAllLines(path);
       foreach(string s in text)
       {
          if(s.Split(':')[0] == Id.ToString())
          {
             text = s.Split(':');
             break;
          }
       }
       var Id = Convert.ToInt32(text[0]);
       var localPosition = Convert.ToInt32(text[1]);
       var localRotation = Convert.ToInt32(text[2]);
       var localScale = Convert.ToInt32(text[3]);
       return new gameObject(Id, localPosition, localRotation, localScale);
    }
