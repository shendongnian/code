    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1 {
    
        public class BusinessObject {
            public Guid Guid { get; set; }
        }
    
        public class BusinessObjectGuidEqualityComparer<T> : IEqualityComparer<T> where T : BusinessObject {
            #region IEqualityComparer<T> Members
    
            public bool Equals(T x, T y) {
                return (x == null && y == null) || (x != null && y != null && x.Guid.Equals(y.Guid));
            }
    
            /// </exception>
            public int GetHashCode(T obj) {
                if (obj == null) {
                    throw new ArgumentNullException("obj");
                }
    
                return obj.GetHashCode();
            }
    
            #endregion
        }
    
        class Program {
            static void Main(string[] args) {
    
                var comparer = new BusinessObjectGuidEqualityComparer<BusinessObject>();
    
                List<BusinessObject> list1 = new List<BusinessObject>() {
                    new BusinessObject() {Guid = Guid.NewGuid()},
                    new BusinessObject() {Guid = Guid.NewGuid()}
                };
    
                List<BusinessObject> list2 = new List<BusinessObject>() {
                    new BusinessObject() {Guid = Guid.NewGuid()},
                    new BusinessObject() {Guid = Guid.NewGuid()},
                    null,
                    null,
                    list1[0]
                };
    
                var toRemove = list1.Except(list2, comparer).ToArray();
                var toAdd = list2.Except(list1, comparer).ToArray();
    
                // toRemove.Length == 1
                // toAdd.Length == 2
                Console.ReadKey();
            }
        }
    }
