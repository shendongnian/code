      public IEnumerable<SelectListItem> GetTemplates()
            {
                using (MailsEntities5 context = new MailsEntities5())
                {
                    List<SelectListItem> countries = context.templateMails.AsNoTracking()
                        .OrderBy(n => n.Id)
                            .Select(n =>
                            new SelectListItem
                            {
                                Value = n.Id.ToString(),
                                Text = n.name
                            }).ToList();
                    var countrytip = new SelectListItem()
                    {
                        Value = null,
                        Text = "--- Select templates ---"
                    };
                    countries.Insert(0, countrytip);
                    return new SelectList(countries, "Value", "Text");
                }
            }
