     public static IEnumerable<IEnumerable<a>> Section<a>(this IEnumerable<a> source, int length)
            {
    
    
                var enumerator = source.GetEnumerator();
                var continueLoop = true;
                do
                {
                    var list = new List<a>();
                    var index = 0;
                    for (int i = 0; i < length; i++)
                    {
                        if (enumerator.MoveNext())
                        {
                            list.Add(enumerator.Current);
                            index++;
                        }
                        else
                        {
                            continueLoop = false;
                            break;
                        }
                    }
                    if (list.Count > 0)
                    {
                        yield return list;
                    }
                } while (continueLoop);
    
    
            }
