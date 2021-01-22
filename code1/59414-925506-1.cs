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
                if (car1.CreationDate.Equals(car2.CreationDate))
                {
                   returnValue = car1.Name.CompareTo(car2.Name);
                }
                else
                {
                   returnValue = car2.CreationDate.CompareTo(car1.CreationDate);
                }
             }
             return returnValue;
          }
       
          #endregion
       }
    }
