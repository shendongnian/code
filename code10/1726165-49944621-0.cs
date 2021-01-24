    var dico = actions
        .GroupBy(x => x.ApprovalRequestType)
        .ToDictionary(
            gdc => gdc.Key,
            gdc => gdc.GroupBy(a => a.Step)
                .ToDictionary(dd => dd.Key, dd => dd.GroupBy(x => new { x.Name, x.Step, x.ApprovalRequestType }, (key, group) => new {
                    Key = key.Name,
                    Result = group.ToDictionary(k => k.ParameterName, v => v.ParameterValue)
                }).First()
            )
        );
