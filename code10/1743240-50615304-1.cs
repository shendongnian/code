    public class PMTaskPXExt : PXCacheExtension<PMTask>
    {
        public abstract class usrSortingTaskCD : IBqlField { }
        [PXString(IsUnicode = true)]
        [PXUIField(DisplayName = "Usr Task")]
        [PXFormula(typeof(HierarchySorting<PMTask.taskCD>))]
        public virtual string UsrSortingTaskCD { get; set; }
    }
