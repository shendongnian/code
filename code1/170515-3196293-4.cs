    public static string 
    GetDescription (this Enum  @enum)
    {
       StringBuilder  builder;
       
       var  descriptionAttributes = @enum.GetType ()
                                         .GetCustomAttributes (
                                              typeof (DescriptionAttribute),
                                              false) as DescriptionAttribute [];
       
       if (descriptionAttributes == null || descriptionAttributes.Length == 0)
          return string.Empty;
          
       builder = new StringBuilder ();
       
       foreach (DescriptionAttribute  description in descriptionAttributes)
       {
          builder.Append (description.Description);
          builder.AppendLine ();
       }
       
       return builder.ToString ();
    }
    
