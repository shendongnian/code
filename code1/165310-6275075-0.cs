    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using System.Data.Objects;
    using System.Data.Linq;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    namespace NorthwindModel
    {
    
        public partial class NorthwindEntities
        {
            partial void OnContextCreated()
            {
                // Register the handler for the SavingChanges event. 
                this.SavingChanges += new EventHandler(context_SavingChanges);
            }
        
            // SavingChanges event handler. 
            private static void context_SavingChanges(object sender, EventArgs e)
            {
                var objects = ((ObjectContext)sender).ObjectStateManager;
        
                // Get new objects
                foreach (ObjectStateEntry entry in objects.GetObjectStateEntries(EntityState.Added))
                {
                    // Find an object state entry for a SalesOrderHeader object.  
                    if (entry.Entity.GetType() == typeof(Employee))
                    {
                        var usr = entry.Entity as Employee;
        
                        // Do your Business Logic here.
                    }
                }
            }
        }
    }
