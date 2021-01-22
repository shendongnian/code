    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace GameEngineInterpreter
    {
        public class VariableList<T>
        {
            private List<string> list1;
            private List<T> list2;
    
            /// <summary>
            /// Initialize a new Variable List
            /// </summary>
            public VariableList()
            {
                list1 = new List<string>();
                list2 = new List<T>();
            }
    
            /// <summary>
            /// Set the value of a variable. If the variable does not exist, then it is created
            /// </summary>
            /// <param name="variable">Name or ID of the variable</param>
            /// <param name="value">The value of the variable</param>
            public void Set(string variable, T value)
            {
                if (!list1.Contains(variable))
                {
                    list1.Add(variable);
                    list2.Add(value);
                }
                else
                {
                    list2[list1.IndexOf(variable)] = value;
                }
            }
    
            /// <summary>
            /// Remove the variable if it exists
            /// </summary>
            /// <param name="variable">Name or ID of the variable</param>
            public void Remove(string variable)
            {
                if (list1.Contains(variable))
                {
                    list2.RemoveAt(list1.IndexOf(variable));
                    list1.RemoveAt(list1.IndexOf(variable));
                }
            }
    
            /// <summary>
            /// Clears the variable list
            /// </summary>
            public void Clear()
            {
                list1.Clear();
                list2.Clear();
            }
    
            /// <summary>
            /// Get the value of the variable if it exists
            /// </summary>
            /// <param name="variable">Name or ID of the variable</param>
            /// <returns>Value</returns>
            public T Get(string variable)
            {
                if (list1.Contains(variable))
                {
                    return (list2[list1.IndexOf(variable)]);
                }
                else
                {
                    return default(T);
                }
            }
    
            /// <summary>
            /// Get a string list of all the variables 
            /// </summary>
            /// <returns>List string</string></returns>
            public List<string> GetList()
            {
                return (list1);
            }
        }
    }
