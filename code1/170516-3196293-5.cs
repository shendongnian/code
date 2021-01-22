    public sealed class DescriptionAttribute : Attribute
    {
       public 
       DescriptionAttribute (string  description)
       {
          m_description = description;
       }
       
       public string 
       Description
       {
          get
          {
              return m_description;
          }
       }
       private readonly string m_description;
    }
