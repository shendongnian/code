    public class MyObject
    {
         private string _content = string.Empty;
         public bool Trim { get; set; }
         
         public string Content
         {
              get
              {
                   return this.Trim ? _content.Trim() : _content;
              }
              internal set
              {
                   if (string.IsNullOrEmpty(value))
                        _content = string.Empty; 
                   else
                        _content = value;
              }
         }
    }
