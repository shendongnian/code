    /// <summary>
    /// Checks each field to ensure it has properly formatted options
    /// </summary>
    /// <param name="field"></param>
    /// <returns>An array of options that have been safely formatted</returns>
    private static string[] VetField(Field field)
    {
        List<string> options = new List<string>();
        foreach (Field kid in field.Kids)
        {
            bool different = false;
            DictAtom ap1 = kid.Resolve(Atom.GetItem(kid.Atom, "AP")) as DictAtom;
            if (ap1 == null) continue;
            DictAtom ap2 = new DictAtom();
            foreach (var pair1 in ap1)
            {
                DictAtom apType1 = kid.Resolve(pair1.Value) as DictAtom;
                Debug.Assert(apType1 != null); // should never happen
                DictAtom apType2 = new DictAtom();
                ap2[pair1.Key] = apType2;
                foreach (var pair2 in apType1)
                {
                    string name1 = pair2.Key;
                    StringBuilder sb = new StringBuilder();
                    foreach (char c in name1)
                    {
                        if (c < 128)
                            sb.Append(c);
                    }
                    string name2 = sb.ToString();
                    if (name1 != name2)
                        different = true;
                    apType2[name2] = pair2.Value;
                    if (pair1.Key == "N")
                        options.Add(name2);
                }
            }
            if (different)
                    ((DictAtom)kid.Atom)["AP"] = ap2;
        }
        return options.ToArray();
    }
