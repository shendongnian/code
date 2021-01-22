 Cs
                statements.OfType<CodeAssignStatement>()
                    .Where(s => s.Left is CodePropertyReferenceExpression && ((CodePropertyReferenceExpression)s.Left).PropertyName == "Text")
                    .ToList().ForEach(s =>
                    {
                        s.Right = new CodeMethodInvokeExpression(
                            new CodeMethodReferenceExpression(new CodeTypeReferenceExpression("Core.DisplayText"), "GetDisplayText"),
                            s.Right);
                    });
However I am still experimenting with it and I haven't created a working solution yet... But it may help you.
:-)
