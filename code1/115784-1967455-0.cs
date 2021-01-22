    public int LoginEnabledPropertyValue { get; set; }
    [SubSonicIgnore]
    public bool LoginEnabled
    {
         get
         {
              return (LoginEnabledPropertyValue > 0 ? true : false);
         }
         set
         {
              LoginEnabledPropertyValue = (value ? 1 : 0);
         }
     }
