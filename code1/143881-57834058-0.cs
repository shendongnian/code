    public static string GetGoodName(this Type type)
    {
        var sb = new StringBuilder();
        void VisitType(Type inType)
        {
            if (inType.IsArray)
            {
                var rankDeclarations = new Queue<string>();
                Type elType = inType;
                do
                {
                    rankDeclarations.Enqueue($"[{new string(',', elType.GetArrayRank() - 1)}]");
                    elType = elType.GetElementType();
                } while (elType.IsArray);
                VisitType(elType);
                while (rankDeclarations.Count > 0)
                {
                    sb.Append(rankDeclarations.Dequeue());
                }
            }
            else
            {
                if (inType.IsGenericType)
                {
                    var isNullable = inType.IsNullable();
                    var genargs = inType.GetGenericArguments().AsEnumerable();
                    var numer = genargs.GetEnumerator();
                    numer.MoveNext();
                    if (!isNullable) sb.Append($"{inType.Name.Substring(0, inType.Name.IndexOf('`'))}<");
                    VisitType(numer.Current);
                    while (numer.MoveNext())
                    {
                        sb.Append(",");
                        VisitType(numer.Current);
                    }
                    if (isNullable)
                    {
                        sb.Append("?");
                    }
                    else
                    {
                        sb.Append(">");
                    }
                }
                else
                {
                    sb.Append(inType.Name);
                }
            }
        }
        VisitType(type);
        var s = sb.ToString();
        return s;
    }
