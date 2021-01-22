    internal void Save(BinaryWriter w)
    {
        w.Write(this.id);
        w.Write(this.name);
        byte[] bytes = Encoding.UTF8.GetBytes(this.MyString);
        w.Write(bytes.Length);
        w.Write(bytes);
        w.Write(this.tags.Count); // nested struct/class        
        foreach (Tag tag in this.tags)
        {
            tag.Save(w);
        }
    }
