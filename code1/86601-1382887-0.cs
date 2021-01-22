    public List<string> GetNamesOfTag(List<Tag> tags)
    {
       List<string> Name = new List<string>();
       foreach(Tag item in tags)
       {
         Name.Add(item.name);
       }
    
       returns Name;
    }
