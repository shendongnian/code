            public class ConditionSense : SwitchCase<int?>
            {
                public ConditionSense()
                {
                    Cases = new List<ICase<int?>>
                    {
                        new CaseSmile(),
                        new CaseCry()
                    };
                    DefaultCases = new List<ICase<int?>> {
                        new CaseNoSense()
                    };
                }
                public void Switch(int? key)
                {
                    IEnumerable<IAction> matches = Cases.Where(p => p.Key.Equals(key))
                        .Select(p => p as IAction);
                    if (matches.Count() > 0)
                        foreach (IAction match in matches)
                            match.Do();
                    else
                        foreach (IAction defaultCase in DefaultCases)
                            defaultCase.Do();
                }
            }
