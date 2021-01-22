    private static void GetP(List<List<string>> conditions, List<List<string>> combinations, List<string> conditionCombo, List<string> previousT)
    {
        for (int i = 0; i < conditions.Count(); i++)
        {
            List<string> oneField = conditions[i];
            for (int k = 0; k < oneField.Count(); k++)
            {
                List<string> t = new List<string>(conditionCombo);
                t.AddRange(previousT);
                t.Add(oneField[k]);
    
                if (1 == conditions.Count )
                {
                    combinations.Add(t);
                    continue;
                }
                GetP(conditions.GetRange(i + 1, conditions.Count - 1 - i), combinations, conditionCombo, t);
            }
    
        }
    }
    List<List<string>> a = new List<List<string>>();
    a.Add(new List<string> { "1", "5", "3", "9" });
    a.Add(new List<string> { "2", "3" });
    a.Add(new List<string> { "93" });
    List<List<string>> result = new List<List<string>>();
    GetP(a, result, new List<string>(), new List<string>());
