    public ChannelObjectModel GetChannelObjectModel(Guid id)
    {
        var set = ctx.BuildChannelObject(); // ctx is this
    
        var channelModel = set.FirstOrDefault(x => x.Id == id); // this loads the first level
    
        LoadRecursive(channelModel, set);
    
        return channelModel;
    }
    
    private void LoadRecursive(ChannelObjectModel c, IQueryable<ChannelObjectModel> set)
    {
         if(c == null)
             return; // recursion end condition
       
         c.ParentObject = set.FirstOrDefault(x => x.Id == c?.ParentObject.Id);
        // all other properties
    
         LoadRecursive(c.ParentObject, set);
        // all other properties
    }
            
