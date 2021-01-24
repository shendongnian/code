    public class SOLineExt : PXCacheExtension<SOLine>
    {
        #region TestField
        [PXString]
        [PXStringList()]
        [PXUIField(DisplayName = "Acumatica Field")]
        public string TestField { get; set; }
        public abstract class testField : IBqlField { }
        #endregion
    }
