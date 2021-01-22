    private void Child_Update(Invoice parent)
    {
          using (var ctx = Csla.Data.ContextManager
               .GetManager(Database.ApplicationConnection, false))
          {
               var data = new Gimli.Data.InvoiceItem()
               {
                    InvoiceItemId = ReadProperty(InvoiceItemIdProperty)
               };
    
               ctx.DataContext.InvoiceItems.Attach(data);
    
               if (this.IsSelfDirty)
               {
                    // Update properties
               }
         }
    }
