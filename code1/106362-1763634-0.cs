    obj1.Prop1 != obj2.Prop1
         ? obj1.Prop1.CompareTo(obj2.Prop1)
         : obj1.Prop2 != obj2.Prop2
               ? obj1.Prop2.CompareTo(obj2.Prop2)
               : obj1.Prop3 != obj2.Prop3
                      ? obj1.Prop3.CompareTo(obj2.Prop3)
                      : obj1.Prop4.CompareTo(obj2.Prop4);
