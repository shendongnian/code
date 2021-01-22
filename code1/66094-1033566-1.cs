    public TGender Gender
    {
       switch(this.DbGender)
       {
          case "M":
            return TGender.Male;
       }
    }
