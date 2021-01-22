    //---------------------------------------------------------------------
    //  Copyright (C) Microsoft Corporation.  All rights reserved.
    // 
    //THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
    //KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    //IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
    //PARTICULAR PURPOSE.
    //---------------------------------------------------------------------
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Reflection;
    using System.Collections;
    
    namespace SomethingSomething
    {
        /// <summary>
        /// Supports sorting of list in data grid view.
        /// </summary>
        /// <typeparam name="T">Type of object to be displayed in data grid view.</typeparam>
        public class SortableSearchableList<T> : BindingList<T>
        {
            #region Delegates
    
            /// <summary>
            /// Custom comparer for an item in the list.
            /// </summary>
            /// <param name="item1">LHS item.</param>
            /// <param name="item2">RHS item.</param>
            /// <param name="property">Property to base comparison on.</param>
            /// <returns>Standard comparison return value (whatever that is).</returns>
            public delegate int CompareProperty(T item1, T item2, PropertyDescriptor property);
    
            #endregion
    
            #region Data Members
    
            private ListSortDirection _sortDirectionValue;
            private PropertyDescriptor _sortPropertyValue = null;
    
            /// <summary>
            /// Dictionary from property name to custom comparison function.
            /// </summary>
            private Dictionary<string, Comparison<T>> _customComparisons = new Dictionary<string, Comparison<T>>();
    
            #endregion
    
            #region Constructors
    
            /// <summary>
            /// Default constructor.
            /// </summary>
            public SortableSearchableList()
            {
            }
    
            #endregion
    
            #region Properties
    
            /// <summary>
            /// Indicates if sorting is supported.
            /// </summary>
            protected override bool SupportsSortingCore
            {
                get
                {
                    return true;
                }
            }
    
            /// <summary>
            /// Indicates if list is sorted.
            /// </summary>
            protected override bool IsSortedCore
            {
                get
                {
                    return _sortPropertyValue != null;
                }
            }
    
            /// <summary>
            /// Indicates which property the list is sorted.
            /// </summary>
            protected override PropertyDescriptor SortPropertyCore
            {
                get
                {
                    return _sortPropertyValue;
                }
            }
    
            /// <summary>
            /// Indicates in which direction the list is sorted on.
            /// </summary>
            protected override ListSortDirection SortDirectionCore
            {
                get
                {
                    return _sortDirectionValue;
                }
            }
            
            #endregion
    
            #region Methods       
    
            /// <summary>
            /// Add custom compare method for property.
            /// </summary>
            /// <param name="propertyName"></param>
            /// <param name="compareProperty"></param>
            protected void AddCustomCompare(string propertyName, Comparison<T> comparison)
            {
                _customComparisons.Add(propertyName, comparison);
            }
            
            /// <summary>
            /// Apply sort.
            /// </summary>
            /// <param name="prop"></param>
            /// <param name="direction"></param>
            protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
            {
                Comparison<T> comparison;
                if (!_customComparisons.TryGetValue(prop.Name, out comparison))
                {
                    // Check to see if the property type we are sorting by implements
                    // the IComparable interface.
                    Type interfaceType = prop.PropertyType.GetInterface("IComparable");
                    if (interfaceType != null)
                    {
                        comparison = delegate(T t1, T t2)
                            {
                                IComparable val1 = (IComparable)prop.GetValue(t1);
                                IComparable val2 = (IComparable)prop.GetValue(t2);
                                return val1.CompareTo(val2);
                            };
                    }
                    else
                    {
                        // Last option: convert to string and compare.
                        comparison = delegate(T t1, T t2)
                            {
                                string val1 = prop.GetValue(t1).ToString();
                                string val2 = prop.GetValue(t2).ToString();
                                return val1.CompareTo(val2);
                            };
                    }
                }
    
                if (comparison != null)
                {
                    // If so, set the SortPropertyValue and SortDirectionValue.
                    _sortPropertyValue = prop;
                    _sortDirectionValue = direction;
    
                    // Create sorted list.
                    List<T> _sortedList = new List<T>(this);                   
                    _sortedList.Sort(comparison);
    
                    // Reverse order if needed.
                    if (direction == ListSortDirection.Descending)
                    {
                        _sortedList.Reverse();
                    }
    
                    // Update list.
                    int count = this.Count;
                    for (int i = 0; i < count; i++)
                    {
                        this[i] = _sortedList[i];
                    }
                                   
                    // Raise the ListChanged event so bound controls refresh their
                    // values.
                    OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                }
            }
    
            // Method below was in the original implementation from MS. Don't know what it's for.
            // -- Martijn Boeker, Jan 21, 2010
    
            //protected override void RemoveSortCore()
            //{
            //    //int position;
            //    //object temp;
            //    //// Ensure the list has been sorted.
            //    //if (unsortedItems != null)
            //    //{
            //    //    // Loop through the unsorted items and reorder the
            //    //    // list per the unsorted list.
            //    //    for (int i = 0; i < unsortedItems.Count; )
            //    //    {
            //    //        position = this.Find(SortPropertyCore.Name,
            //    //            unsortedItems[i].GetType().
            //    //            GetProperty(SortPropertyCore.Name).
            //    //            GetValue(unsortedItems[i], null));
            //    //        if (position >= 0 && position != i)
            //    //        {
            //    //            temp = this[i];
            //    //            this[i] = this[position];
            //    //            this[position] = (T)temp;
            //    //            i++;
            //    //        }
            //    //        else if (position == i)
            //    //            i++;
            //    //        else
            //    //            // If an item in the unsorted list no longer exists, delete it.
            //    //            unsortedItems.RemoveAt(i);
            //    //    }
            //    //    OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            //    //}
            //}
    
            /// <summary>
            /// Ability to search an item.
            /// </summary>
            protected override bool SupportsSearchingCore
            {
                get
                {
                    return true;
                }
            }
                    
            /// <summary>
            /// Finds an item in the list.
            /// </summary>
            /// <param name="prop"></param>
            /// <param name="key"></param>
            /// <returns></returns>
            protected override int FindCore(PropertyDescriptor prop, object key)
            {
                // Implementation not changed from MS example code.
    
                // Get the property info for the specified property.
                PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);
                T item;
    
                if (key != null)
                {
                    // Loop through the the items to see if the key
                    // value matches the property value.
                    for (int i = 0; i < Count; ++i)
                    {
                        item = (T)Items[i];
                        if (propInfo.GetValue(item, null).Equals(key))
                            return i;
                    }
                }
                return -1;
            }
    
            /// <summary>
            /// Finds an item in the list.
            /// </summary>
            /// <param name="prop"></param>
            /// <param name="key"></param>
            /// <returns></returns>
            private int Find(string property, object key)
            {
                // Implementation not changed from MS example code.
    
                // Check the properties for a property with the specified name.
                PropertyDescriptorCollection properties =
                    TypeDescriptor.GetProperties(typeof(T));
                PropertyDescriptor prop = properties.Find(property, true);
    
                // If there is not a match, return -1 otherwise pass search to
                // FindCore method.
                if (prop == null)
                    return -1;
                else
                    return FindCore(prop, key);
            }
    
            #endregion
        }
    }
