     methodName = NwSheet.Cells[rCnt1, cCnt1 - 2].Value2;
                                Type nameSpace=typeof(ReadExcel);
                                Type metdType = Type.GetType(nameSpace.Namespace + "." + methodName);
                                //ConstructorInfo magicConstructor = metdType.GetConstructor(Type.EmptyTypes);
                                //object magicClassObject = magicConstructor.Invoke(new object[] { });
                                object magicClassObject = Activator.CreateInstance(metdType);
                                MethodInfo mthInfo = metdType.GetMethod("fn_"+methodName);
                                StaticVariable.dtReadData.Clear();
                                for (iCnt = cCnt1 + 4; iCnt <= ShtRange.Columns.Count; iCnt++)
                                {
                                    temp = NwSheet.Cells[1, iCnt].Value2;
                                    StaticVariable.dtReadData.Add(temp.Trim(), Convert.ToString(NwSheet.Cells[rCnt1, iCnt].Value2));
                                }
    
                                
                                //if (Convert.ToString(NwSheet.Cells[rCnt1, cCnt1 - 2].Value2) == "fn_AddNum" || Convert.ToString(NwSheet.Cells[rCnt1, cCnt1 - 2].Value2) == "fn_SubNum")
                                //{
                                //    //StaticVariable.intParam1 = Convert.ToInt32(NwSheet.Cells[rCnt1, cCnt1 + 4].Value2);
                                //    //StaticVariable.intParam2 = Convert.ToInt32(NwSheet.Cells[rCnt1, cCnt1 + 5].Value2);
                                //    object[] mParam1 = new object[] { Convert.ToInt32(StaticVariable.dtReadData["InParam1"]), Convert.ToInt32(StaticVariable.dtReadData["InParam2"]) };
                                //    object result = mthInfo.Invoke(this, mParam1);
                                //    StaticVariable.intOutParam1 = Convert.ToInt32(result);
                                //    NwSheet.Cells[rCnt1, cCnt1 + 2].Value2 = Convert.ToString(StaticVariable.intOutParam1) != "" ? Convert.ToString(StaticVariable.intOutParam1) : String.Empty;
                                //}
    
                                //else
                                //{
                                    object[] mParam = new object[] { };
                                    mthInfo.Invoke(magicClassObject, mParam);
