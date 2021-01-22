    public class ProjectMappingOverride : IAutoMappingOverride<Project>
    {
        public void Override(AutoMapping<Project> mapping)
        {
            mapping.Id(x => x.ProjectId); //Usually for Id I have a convention, and not define it here
            mapping.Map(x => x.Title); //Also for simple properties. You could remove these lines if you have setup the conventions.
            mapping.References(x => x.ProjectManager);
            mapping.References(x => x.Contact);
        }
    }
