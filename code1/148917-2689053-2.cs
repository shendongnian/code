    using System.Web.Mvc.Extensibility;
    
    namespace UI.Model
    {
        public class StoreInputMetadata : ModelMetadataConfigurationBase<StoreInput>
        {
            public StoreInputMetadata()
            {
                Configure(m => m.Id)
                    .Hide();
                Configure(model => model.Name)
                    .Required(Resources.Whatever.StoreIsRequired)
                    .MaximumLength(64, Resources.Whatever.StoreNameLengthSomething);
            }
        }
    }
