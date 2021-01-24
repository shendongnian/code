    using System;
    using PX.Data;
    
    namespace ModelCustom
    {
      [Serializable]
      public class ModelNumber : IBqlTable
      {
        #region ModelID
        [PXDBIdentity()]
        [PXUIField(DisplayName = "Model ID")]
        public virtual int? ModelID { get; set; }
        public abstract class modelID : IBqlField { }
        #endregion
    
        #region ModelCD
        [PXDBString(50, IsUnicode = true, InputMask = "", IsKey = true)]
        [PXDefault]
        [PXUIField(DisplayName = "Model Number")]
        [PXSelector(typeof(Search<ModelNumber.modelCD>),
        typeof(ModelNumber.modelCD),
        typeof(ModelNumber.description))]
        public virtual string ModelCD { get; set; }
        public abstract class modelCD : IBqlField { }
        #endregion
    
        #region Description
        [PXDBString(500, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        public abstract class description : IBqlField { }
        #endregion
      }
    }
