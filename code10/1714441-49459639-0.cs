       public static bool operator ==(TestResult obj1, TestResult obj2) {
                if (ReferenceEquals(obj1, obj2)) {
                    return true;
                }
    
                if (ReferenceEquals(obj1, null)) {
                    return false;
                }
                if (ReferenceEquals(obj2, null)) {
                    return false;
                }
    
                bool areEqual = false;
    
                if (obj1.LabelName == obj2.LabelName) {
                    areEqual = true;
                }
    
                if (obj1.SelectedValues?.Count != obj2.SelectedValues?.Count) {
                    return false;
                }
    
                //Order to make sure that they are in correct order to be compared
                obj1.SelectedValues = obj1.SelectedValues.OrderBy(x => x).ToList();
                obj2.SelectedValues = obj2.SelectedValues.OrderBy(x => x).ToList();
    
                for (int i = 0; i < obj1.SelectedValues.Count; i++) {
                    var type = obj1.SelectedValues[i].GetType();
                    //Use a dynamic so I can cast to the correct types at run time and compare
                    dynamic castedObj1Val = Convert.ChangeType(obj1.SelectedValues[i], type);
                    dynamic castedObj2Val = Convert.ChangeType(obj2.SelectedValues[i], type);
                    if (castedObj1Val != castedObj2Val)
                        return false;
                }
    
                return areEqual;
            }
