      for (int i = 0; i < typeof(DepartmentEnum).GetFields().Length - 1; i++)
                {
                    DepartmentEnum de = EnumExtensions.NumberToEnum<DepartmentEnum>(i);
                    pairs.Add(new KeyValuePair<string, string>(de.ToDescription(), de.ToString()));
                }
