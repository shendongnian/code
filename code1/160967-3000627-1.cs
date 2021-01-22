    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(x => x.ProjectId);
            Map(x => x.Title);
            References(x => x.ProjectManager);
            References(x => x.Contact);
        }
    }
