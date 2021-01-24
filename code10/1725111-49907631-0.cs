    public class DynamicDropdownAttribute : PXStringListAttribute
    {
        private string[] Values2 = { "A", "C" };
        private string[] Labels2 = { "Alpha", "Charlie" };
        private string[] Values3 = { "N", "C" };
        private string[] Labels3 = { "November", "Charlie" };
        public DynamicDropdownAttribute()
            : base()
        {
        }
        public override void CacheAttached(PXCache sender)
        {
            base.CacheAttached(sender);
            var company = PX.Data.Update.PXInstanceHelper.CurrentCompany;
            if (company == 2)
            {
                this._AllowedValues = Values2;
                this._AllowedLabels = Labels2;
            }
            else if (company == 3)
            {
                this._AllowedValues = Values3;
                this._AllowedLabels = Labels3;
            }
        }
    }
    public class SOOrderPXExt : PXCacheExtension<SOOrder>
    {
        [PXString(1)]
        [PXUIField(DisplayName = "Process")]
        [DynamicDropdown]
        public virtual string UsrProcess { get; set; }
        public abstract class usrProcess : IBqlField { }
    }
