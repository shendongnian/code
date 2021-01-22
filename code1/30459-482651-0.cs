        private void Sort_version2(string propertyName)
        {
            // convert to list
            List<MyClass> myCurrentClass = Items as List<MyClass>;
            string typeOfProperty;
            PropertyInfo pi;
            // sort
            if ((myCurrentClass != null) && (MyClass.HasDetailAndExtract(propertyName, out typeOfProperty, out pi)))
            {
                switch(typeOfProperty)
                {
                    case "System.String":
                        myCurrentClass.Sort(delegate(MyClass one, MyClass two)
                                                {
                                                    return
                                                        Comparer<string>.Default.Compare(pi.GetValue(one, null).ToString(),
                                                                                         pi.GetValue(two, null).ToString());
                                                });
                        break;
                    case "System.Int32":
                        myCurrentClass.Sort(delegate (MyClass one, MyClass two)
                                                {
                                                    return
                                                        Comparer<int>.Default.Compare(
                                                            Convert.ToInt32(pi.GetValue(one, null)),
                                                            Convert.ToInt32(pi.GetValue(two, null)));
                                                });
                        break;
                    default:
                        throw new NotImplementedException("Type of property not implemented yet");
                }
            }
        }
