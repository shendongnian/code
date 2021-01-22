    public string ImagePath
    {
       get
       {
         return File.Exists(m_Path) ? m_Path : null;
       }
    }
