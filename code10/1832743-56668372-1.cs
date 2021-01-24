           public override async Task OnConnectedAsync()
           {
             var Oid = (Context.User.FindFirst(c => 
                       c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier"))?.Value;
             Debug.WriteLine(Oid);
           }
