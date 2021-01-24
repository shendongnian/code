    @(Html.DevExtreme().Form()
            .ID("form")
            .FormData(Model)
            .ColCount(12)
            .ShowValidationSummary(true)
            .Items(i =>
            {
                i.AddSimple()
                .ColSpan(6)
                .Label(l => l.Visible(false))
                .DataField(Model.Lang.ToString())
                .Editor(ed => ed.SelectBox()
                                .DataSource(Model.LangArray)
                                .DisplayExpr("LangName") // displayed text
                                .ValueExpr("LangID") // selected value for submit
                                .Placeholder("Language..."));
            }))
