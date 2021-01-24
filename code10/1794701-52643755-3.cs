    @(Html.DevExtreme().Form()
    .ID("form")
    .ColCount(4)
    .ShowValidationSummary(true)
    .Items(items =>
    {
        if (Model.Where(w => w.TagHtml.Equals("div")).Count() > 0)
        {
            items.AddGroup()
                .Caption("Social networks")
                .ColSpan(4)
                .ColCount(12)
                .Items(socialGroup =>
                {
                    if (it.Style != null && it.Style != string.Empty)
                    {
                        JObject json = JObject.Parse(it.Style);
    
                        socialGroup.AddSimple()
                            .ColSpan(12)
                            .Template(
                                @<text>
                                   @RenderDXAccordion()
                                </text>);
                    }
                });
        }
    }));
