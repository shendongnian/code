    List<RawDataDTO> raw = // your data in raw format
    List<QuestionarieDisplay> list = raw
        .GroupBy(r => new { r.QuestionnaireGroup, r.QuestionnaireGroupId, r.QuestionnaireId })
        .Select(r => new QuestionarieDisplay()
        {
            QuestionnaireId = r.Key.QuestionnaireId,
            QuestionnaireGroupId = r.Key.QuestionnaireGroupId,
            QuestionnaireGroup = r.Key.QuestionnaireGroup,
            QuestionTypeList =
                r.GroupBy(t => new { t.QuestionType, t.QuestionTypeId })
                .Select(t => new QuestionTypeList
                {
                    QuestionType = t.Key.QuestionType,
                    QuestionTypeId = t.Key.QuestionTypeId,
                    QuestionList = t.Select(x => new QuestionList
                        {
                            QuestionId = x.QuestionId
                        })
                    .ToList()
                })
                .ToList()
        }).ToList();
