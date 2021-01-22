    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace Yournamespace
    {
       class CarNameComparer : IComparer<Car>
       {
          #region IComparer<Car> Members
    
          public int Compare(Car car1, Car car2)
          {
             int returnValue = 1;
             if (car1 != null && car2 == null)
             {
                returnValue = 0;
             }
             else if (car1 == null && car2 != null)
             {
                returnValue = 0;
             }
             else if (car1 != null && car2 != null)
             {
                if (car1.Name.Equals(car2.Name))
                {
                   returnValue = car1.CarMaker.CompareTo(car2.CarMaker);
                }
                else
                {
                   returnValue = car2.Name.CompareTo(car1.Name);
                }
             }
             return returnValue;
          }
       
          #endregion
       }
    }
