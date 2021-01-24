    public class HtmlToMarkdownAction : IMappingAction<Entity, EntityViewModel>
    {
        public void Process(Entity source, EntityViewModel destination)
        {
            destination.Description = source.Description; // Convert to HTML
        }
    }
    cfg.CreateMap<Entity, EntityViewModel>()
        .AfterMap<HtmlToMarkdownAction>();
