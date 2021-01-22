    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.DynamicData;
    using System;
    using System.Data;
    using System.Data.Objects;
    namespace AdventureWorksLTModel 
    {
        public partial class AdventureWorksLTEntities 
        {
            partial void OnContextCreated() 
            {
                this.SavingChanges += new System.EventHandler(OnSavingChanges);
            }
            public void OnSavingChanges(object sender, System.EventArgs e) 
            {
                var stateManager = ((AdventureWorksLTEntities)sender).ObjectStateManager;
                var changedEntities = ObjectStateManager.GetObjectStateEntries (EntityState.Modified | EntityState.Added);
                // validation check logic
                throw new ValidationException("Something went wrong.");
            }
        }
    }
