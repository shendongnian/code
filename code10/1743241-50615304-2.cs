    public class ProjectEntryPXDemoExt : PXGraphExtension<ProjectEntry>
    {
        public override void Initialize()
        {
            Base.Tasks.OrderByNew<OrderBy<Asc<PMTaskPXExt.usrSortingTaskCD>>>();
        }
    }
