    var results = db.Events
                    .Include(e => e.EventDates).ThenInclude(ed => ed.EventDatesContacts)
                    .SelectMany(e => e.EventDates.Select(ed => new Result {
                        EventID = e.ID,
                        EventName = e.Name,
                        FromDateTime = ed.FromDateTime,
                        ToDateTime = ed.ToDateTime,
                        Overrides = ed.EventDatesContacts.GroupBy(edc => new {
                                FromTime = edc.OverrideFromTime == null ? ed.FromDateTime : edc.OverrideFromTime.Value,
                                ToTime = edc.OverrideToTime == null ? ed.ToDateTime : edc.OverrideToTime.Value
                            },
                            edc => edc.ContactID
                            )
                            .Select(edcg => new EventOverride {
                                OverrideFromHour = edcg.Key.FromTime,
                                OverrideToHour = edcg.Key.ToTime,
                                ContactIDs = edcg.ToList()
                            })
                            .ToList()
                    }));
