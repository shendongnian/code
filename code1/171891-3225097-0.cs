    public int PageNumber
    {  
         get
         {         
              object value == this.ViewState["PageNumber"];
              if(value != null)
              { 
                   return (int)value;
              }
              else
              {
                   return 1;
              }
         }
         set
         { 
              this.ViewState["PageNumber"] = value;
         }
    }
         
