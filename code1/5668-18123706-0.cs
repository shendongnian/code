     public class PropertyCopy<TSource, TTarget> 
                            where TSource: class, new()
                            where TTarget: class, new()
            {
                public static TTarget Copy(TSource src, TTarget trg, params string[] properties)
                {
                    if (src==null) return trg;
                    if (trg == null) trg = new TTarget();
                    var fulllist = src.GetType().GetProperties().Where(c => c.CanWrite && c.CanRead).ToList();
                    if (properties != null && properties.Count() > 0)
                        fulllist = fulllist.Where(c => properties.Contains(c.Name)).ToList();
                    if (fulllist == null || fulllist.Count() == 0) return trg;
                    
                    fulllist.ForEach(c =>
                        {
                            c.SetValue(trg, c.GetValue(src));
                        });
                    
                    return trg;
                }
            }
