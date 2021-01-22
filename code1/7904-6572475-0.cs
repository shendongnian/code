        public static object CopyObject(object input)
        {
            if (input != null)
            {
                object result = Activator.CreateInstance(input.GetType());
                foreach (FieldInfo field in input.GetType().GetFields(Consts.AppConsts.FullBindingList))
                {
                    if (field.FieldType.GetInterface("IList", false) == null)
                    {
                        field.SetValue(result, field.GetValue(input));
                    }
                    else
                    {
                        IList listObject = (IList)field.GetValue(result);
                        if (listObject != null)
                        {
                            foreach (object item in ((IList)field.GetValue(input)))
                            {
                                listObject.Add(CopyObject(item));
                            }
                        }
                    }
                }
                return result;
            }
            else
            {
                return null;
            }
        }
