            public  dynamic ConvertList(Type CallingType)
        {
            dynamic DynamicList;
            if (CallingType == TypeOfValue)
            {
                Type d1 = typeof(List<>);
                Type[] typeArgs = { TypeOfValue };
                Type DynamicListType = d1.MakeGenericType(typeArgs);
                object DynamicListObj = Activator.CreateInstance(DynamicListType);
                DynamicList = Convert.ChangeType(DynamicListObj, DynamicListType);
               
                foreach (object ValueElement in ValueRange)
                {
                        dynamic el = Convert.ChangeType(ValueElement, TypeOfValue);
                        DynamicList.Add(el);
                }
                
            }
            else //retrun empty List but with right type
            {
                Type d1 = typeof(List<>);
                Type[] typeArgs = { CallingType };
                Type DynamicListType = d1.MakeGenericType(typeArgs);
                object DynamicListObj = Activator.CreateInstance(DynamicListType);
                DynamicList = Convert.ChangeType(DynamicListObj, DynamicListType);
            }
            return DynamicList;
        }
