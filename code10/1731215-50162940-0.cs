         public ActionResult search([Bind(Exclude="UserName")] Person person)
          {
              ...
          }
        
          public ActionResult search([Bind(Include="DomainName, NetworkUserId, 
            FirstName, LastName")] Person person)
          {
             ...
          }
