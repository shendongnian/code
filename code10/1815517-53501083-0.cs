    public static List<Variance> DetailedCompare<T>(this T val1, T val2, bool pName = false)
            {
                List<Variance> variances = new List<Variance>();
                FieldInfo[] fi = typeof(T).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                foreach (FieldInfo f in fi) {
                    Variance v = new Variance();
                    PropertyInfo prop = default(PropertyInfo);
                    if (pName) {
                        prop = typeof(T).GetProperties().Where(p => f.Name.Contains(p.Name)).FirstOrDefault();
                    }
                    v.Prop = pName ? (prop != default(PropertyInfo) ? prop.Name : "") : f.Name;
                    v.valA = f.GetValue(val1);
                    v.valB = f.GetValue(val2);
                    if (v.valA != null) {
                        if (!v.valA.Equals(v.valB))
                            variances.Add(v);
                    } else if (v.valB != null) {
                        variances.Add(v);
                    }
                }
                return variances;
            }
