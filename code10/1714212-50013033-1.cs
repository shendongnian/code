            <div class="table-responsive">
                @(Html
                    .Grid(Model.Articles)
                    .Build(columns =>
                    {
                    columns.Add(model => model.title).Titled("title").Encoded(false).RenderedAs(model => $"<a href='/{model.href}'>{model.title}</a>");
                        columns.Add(model => model.href).Titled("href");
                        columns.Add(model => model.update_time).Titled("Last Updated").RenderedAs(m => SiteUtilities.UtcToEasternTime(m.update_time));
                        columns.Add(model => model.username).Titled("Last Updated By");
                        columns.Add(model => model.locked).Titled("Locked").RenderedAs(model => model.locked ? "True" : "False");
                        columns.Add(model => model.views).Titled("Views").RenderedAs(model => model.views.ToString());
                    })
                    .Filterable()
                    .Sortable()
                    .Pageable()
                    .Css("table table-sm table-striped table-hover")
                )
            </div>
