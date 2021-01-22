    var items = contact.Distinct().OrderBy(c => c.Name)
                                  .Select( c => new ListItem
                                  {
                                    Value = c.ContactId.ToString(),
                                    Text = c.Name
                                  });
