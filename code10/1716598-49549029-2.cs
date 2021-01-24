    [HtmlTargetElement("select", Attributes = "state-items")]
    public class StateItemsTagHelper : TagHelper {
        private readonly StateBusiness _stateBusiness;
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }
        public StateItemsTagHelper(StateBusiness stateBusiness) {
            this._stateBusiness = stateBusiness;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output) {
            content.TagMode = TagMode.StartTagAndEndTag;
            var value = For?.Model as string;
            var items = _stateBusiness.GetStateForSelectList()?.Select(state => new SelectListItem {
                 Text = state.Description,
                 Value = state.Code.ToString(),
                 Selected = value == state.Code.ToString()
            })) ?? Enumerable.Empty<SelectListItem>();
            foreach(var item in items) {
                output.Content.AppendHtml(item.ToHtmlContent());
            }
        }
    }
