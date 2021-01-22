     public ResourceStatus Status
     {
         get { return _status; }
         set
         {
             _status = value;
             Notify(Npcea.Status,Npcea.Comments);
         }
     }
