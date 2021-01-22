        public static Hashtable GetItemWithFilter(string Entity, XMLContext contextXML, Hashtable FieldsNameToGet, Hashtable FieldFilter)
        {
            //Get the type
            Type type = Type.GetType("JP.Model.BO." + Entity + ", JPModel");
            Type CtrlCommonType = typeof(CtrlCommon<>).MakeGenericType( type );
            //Making an instance DALXmlRepository<xxx> XMLInstance = new DALXmlRepository<xxx>(contextXML);
            ConstructorInfo ci = CtrlCommonType.GetConstructor(new Type[] { typeof(XMLContext), typeof(String) });
            IControleur DalInstance = (IControleur)ci.Invoke(new object[] { contextXML, null });
            //Building the string type Expression<func<T,bool>> to init the array
            Type FuncType = typeof(Func<,>).MakeGenericType( type ,typeof(bool));
            Type ExpressType = typeof(Expression<>).MakeGenericType(FuncType);
            Array lambda = Array.CreateInstance(ExpressType,FieldFilter.Count);
            MethodInfo method = DalInstance.GetType().GetMethod("GetItem", new Type[] { lambda.GetType() });
            if (method == null)
                throw new InvalidOperationException("GetItem(Array) doesn't exist for " + DalInstance.GetType().GetGenericArguments().First().Name);
            
            int j = 0;
            IDictionaryEnumerator criterias = FieldFilter.GetEnumerator();
            criterias.Reset();
            while (criterias.MoveNext())
            {
                if (!String.IsNullOrEmpty(criterias.Key.ToString()))
                {
                    lambda.SetValue(BuildLambdaExpression(type, criterias.Key.ToString(), criterias.Value.ToString()),j);
                }
                else
                {
                    throw new JPException(JPException.MessageKey.CONTROLER_PARAMFIELD_EMPTY, "GetItemWithFilter", criterias.Key.ToString());
                }
                j++;
            }
            Object item = method.Invoke(DalInstance, new object[] { lambda });
            }
