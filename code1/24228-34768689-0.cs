        public class ObjektHelper
        {
            /// <summary>
            /// Compairs two Objects and gives back true if they are equal
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="obj1">Object 1</param>
            /// <param name="obj2">Object 2</param>
            /// <param name="consideredFieldNames">If the list is not mepty, only the field within equal names are compaired.</param>
            /// <param name="notConsideredFieldNames">If you want not compair some fields enter their name in this list.</param>
            /// <returns></returns>
            public static bool DeepCompare<T>(T obj1, T obj2, string[] consideredFieldNames, params string[] notConsideredFieldNames)
            {
                var errorList = new List<object>();
                if (notConsideredFieldNames == null) notConsideredFieldNames = new[] {""};
                DeepCompare(obj1, obj2, errorList, consideredFieldNames, notConsideredFieldNames, false);
                return errorList.Count <= 0;
            }
            /// <summary>
            /// Compairs two Objects and gives an error list back.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="obj1"></param>
            /// <param name="obj2"></param>
            /// <param name="errorList">The error list gives back the names of the fields that are not equal.</param>
            /// <param name="consideredFieldNames">If the list is not mepty, only the field within equal names are compaired.</param>
            /// <param name="notConsideredFieldNames">If you want not compair some fields enter their name in this list.</param>
            /// <param name="endWithErrors">If the value is false, the method end at the first error.</param>
            public static void DeepCompare<T>(T obj1, T obj2, List<object> errorList, string[] consideredFieldNames, string[] notConsideredFieldNames, bool endWithErrors)
            {
                if (errorList == null) throw new Exception("errorListliste ist NULL");
                if (Equals(obj1, default(T)) && Equals(obj2, default(T))) return;
                if (Equals(obj1, default(T)) || Equals(obj2, default(T)))
                {
                    errorList.Add("One of the object are null!");
                    return;
                }
                if (!endWithErrors && errorList != null && errorList.Count > 0) throw new Exception("ErrorListliste is not empty");
                var type1 = obj1.GetType();
                var type2 = obj2.GetType();
                var propertyInfos1 = type1.GetProperties();
                var propertyInfos2 = type2.GetProperties();
                // To use the access via index, the list have to be ordered!
                var propertyInfoOrdered1 = propertyInfos1.OrderBy(p => p.Name).ToArray();
                var propertyInfoOrdered2 = propertyInfos2.OrderBy(p => p.Name).ToArray();
                if (type1 != type2) errorList.AddRange(new List<object> {type1, type2});
                else
                {
                    for (var i = 0; i < propertyInfos1.Length; i++)
                    {
                        var t1 = propertyInfoOrdered1[i].PropertyType;
                        var t2 = propertyInfoOrdered2[i].PropertyType;
                        if (t1 != t2)
                        {
                            errorList.AddRange(new List<object> {type1, type2});
                            continue;
                        }
                        var name1 = propertyInfoOrdered1[i].Name;
                        var name2 = propertyInfoOrdered2[i].Name;
                        
                        // Use the next 4 lines to find a bug
                        //if (name1 == "Enter name of field with the bug")
                        //    Console.WriteLine(name1);
                        //if (name2 == "Enter name of field1 with the bug" || name2 == "Enter name of field2 with the bug")
                        //    Console.WriteLine(name2);
                        if (consideredFieldNames != null && !consideredFieldNames.Contains(name1)) continue;
                        if (notConsideredFieldNames != null && notConsideredFieldNames.Contains(name1)) continue;
                        var value1 = propertyInfoOrdered1[i].GetValue(obj1, null);
                        var value2 = propertyInfoOrdered2[i].GetValue(obj2, null);
                        // check Attributes
                        var guiName1 = (propertyInfoOrdered1[i].GetCustomAttributes().FirstOrDefault(a => a.GetType() == typeof(GuiNameofModelAttribute)) as GuiNameofModelAttribute)?.GuiName;
                        var guiName2 = (propertyInfoOrdered2[i].GetCustomAttributes().FirstOrDefault(a => a.GetType() == typeof(GuiNameofModelAttribute)) as GuiNameofModelAttribute)?.GuiName;
                        // create errorListrange
                        var temperrorListRange = new List<object>();
                        if (guiName1 != null && guiName2 != null) temperrorListRange.AddRange(new List<object> { guiName1, guiName2 });
                        else temperrorListRange.AddRange(new List<object> { propertyInfoOrdered1[i], propertyInfoOrdered2[i] });
                        // both fields are null = OK
                        if ((value1 == null && value2 == null) || (value1 is Guid && value2 is Guid)) continue;
                        // one of the fields is null = errorList
                        if (value1 == null || value2 == null) errorList.AddRange(temperrorListRange);
                        // Value types, Enum and String compair
                        else if (t1.BaseType == typeof (ValueType) || t1.BaseType == typeof (Enum) || t1 == typeof (string))
                        {
                            if (!value1.Equals(value2)) errorList.AddRange(temperrorListRange);
                        }
                        // List, array, generic lists, collection and bindinglist compair    
                        else if (t1 == typeof (Array) || (t1.IsGenericType && (t1.GetGenericTypeDefinition() == typeof (List<>) ||
                                                                               t1.GetGenericTypeDefinition() == typeof (IList<>) ||
                                                                               t1.GetGenericTypeDefinition() == typeof (Collection<>) ||
                                                                               t1.GetGenericTypeDefinition() == typeof (ICollection<>) ||
                                                                               t1.GetGenericTypeDefinition() == typeof (ObservableCollection<>) ||
                                                                               t1.GetGenericTypeDefinition() == typeof (BindingList<>) ||
                                                                               t1.GetGenericTypeDefinition() == typeof (BindingList<>)
                            )))
                            DeepListCompare(value1 as IEnumerable<object>, value2 as IEnumerable<object>, errorList, consideredFieldNames, notConsideredFieldNames, endWithErrors);
                        // Clas compair
                        else if (t1.IsClass || t1.IsAnsiClass) DeepCompare(value1, value2, errorList, consideredFieldNames, notConsideredFieldNames, endWithErrors);
                        else throw new NotImplementedException();
                        if (!endWithErrors && errorList.Count > 0) break;
                    }
                }
            } // End DeepCompare<T>
            /// <summary>
            /// Compairs two lists and gives back true if they are equal.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="tlist1">Generic list 1</param>
            /// <param name="tlist2">Generic List 2</param>
            /// <returns></returns>
            public static bool DeepListCompare<T>(T tlist1, T tlist2)
            {
                var errorList = new List<object>();
                DeepCompare(tlist1, tlist2, errorList, null, null, false);
                return errorList.Count <= 0;
            }
            /// <summary>
            /// Compairs two lists and gives backthe error list.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="tlist1">Generic list 1</param>
            /// <param name="tlist2">Generic list 2</param>
            /// <param name="errorList">The error list gives back the names of the fields that are not equal.</param>
            /// <param name="consideredFieldNames">If the list is not mepty, only the field within equal names are compaired.</param>
            /// <param name="notConsideredFieldNames">If you want not compair some fields enter their name in this list.</param>
            /// <param name="endWithErrors">If the value is false, the method end at the first error.</param>
            public static void DeepListCompare<T>(T tlist1, T tlist2, List<object> errorList, string[] consideredFieldNames, string[] notConsideredFieldNames, bool endWithErrors)
                where T : IEnumerable<object>
            {
                if (errorList == null) throw new Exception("errorListliste ist NULL");
                if (!endWithErrors && errorList.Count > 0) throw new Exception("errorListliste ist nicht Leer");
                if (Equals(tlist1, null) || Equals(tlist2, null))
                {
                    errorList.AddRange(new List<object> {tlist1, tlist2});
                    return;
                }
                var type1 = tlist1.GetType();
                var type2 = tlist2.GetType();
                var propertyInfos1 = type1.GetProperties();
                var propertyInfos2 = type2.GetProperties();
                // To use the access via index, the list have to be ordered!
                var propertyInfoOrdered1 = propertyInfos1.OrderBy(p => p.Name).ToArray();
                var propertyInfoOrdered2 = propertyInfos2.OrderBy(p => p.Name).ToArray();
                for (var i = 0; i < propertyInfos1.Length; i++)
                {
                    var t1 = propertyInfoOrdered1[i].PropertyType;
                    var t2 = propertyInfoOrdered2[i].PropertyType;
                    if (t1 != t2) errorList.AddRange(new List<object> {t1, t2});
                    else
                    {
                        // Kick out index
                        if (propertyInfoOrdered1[i].GetIndexParameters().Length != 0)
                        {
                            continue;
                        }
                        // Get value
                        var value1 = propertyInfoOrdered1[i].GetValue(tlist1, null) as IEnumerable<object>;
                        var value2 = propertyInfoOrdered2[i].GetValue(tlist2, null) as IEnumerable<object>;
                        if (value1 == null || value2 == null) continue;
                        // Only run through real lists.
                        if (t1 == typeof (Array) ||
                            t1.IsGenericType && t1.GetGenericTypeDefinition() == typeof (List<>) ||
                            t1.IsGenericType && t1.GetGenericTypeDefinition() == typeof (Collection<>))
                        {
                            // cast 
                            var objectList1 = value1.ToList();
                            var objectList2 = value2.ToList();
                            if (objectList1.Count == 0 && objectList1.Count == 0)
                            {
                                //errorList.AddRange(new List<Object> { objectList1, objectList1 });
                                continue;
                            }
                            foreach (var item1 in objectList1)
                            {
                                foreach (var item2 in objectList2)
                                {
                                    var temperrorListCount = errorList.Count;
                                    DeepCompare(item1, item2, errorList, consideredFieldNames, notConsideredFieldNames, endWithErrors);
                                    if (temperrorListCount != errorList.Count) continue;
                                    objectList2.Remove(item2);
                                    break;
                                }
                                if (!endWithErrors && errorList.Count > 0) break;
                            }
                        }
                        else DeepCompare(value1, value2, errorList, consideredFieldNames, notConsideredFieldNames, endWithErrors);
                    }
                    if (!endWithErrors && errorList.Count > 0) break;
                }
            } // End DeepListCompare<T>
        } // end class ObjectHelper
        [AttributeUsage(AttributeTargets.All)]
        public class GuiNameofModelAttribute : Attribute
        {
            public readonly string GuiName;
            public GuiNameofModelAttribute(string guiName)
            {
                GuiName = guiName;
            }
        }
