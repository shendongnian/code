    public void AddToContents(W content);
    {  
       if(content.Container!=null) content.Container.RemoveFromContents(content);
        content.Container = this;
        _contentsW.Add(content);
    }
