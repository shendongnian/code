    for (int i = OldCombo.Count - 1; i >=0; i--)
                {
                    Match m = Regex.Match(OldCombo[i], pattern);
                    if (m.Success && m.Length <= emaillower)
                        OldCombo.RemoveAt(i);
                }
