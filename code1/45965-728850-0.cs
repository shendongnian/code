    public void SetImage(ImageSource source)
    {
       ImageSource src = null;
       if(!source.IsFrozen)
           src = source.GetAsFrozen();
       else
           src = source; 
       this.BackgroundImage.Source = src;
    }
