    public class MarkDownToHtmlConverter : IValueConverter<string, string>
    {
        public string Convert(string sourceMember, ResolutionContext context)
        {
            // Convert to HTML here
            string html = sourceMember;
            return html;
        }
    }
    cfg.CreateMap<Entity, EntityViewModel>()
        .ForMember(x => x.Description, opt => opt.ConvertUsing(new MarkDownToHtmlConverter()));
