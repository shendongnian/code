    public int ImageGroupLength
    {
      get
      { 
        int ret;
        int.TryParse(this.imageGroupLength.Text, out ret);
    
        return ret; //Ret will be 0 if tryparse fails
      }
      set
      {
        ...
      }
    }
