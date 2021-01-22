    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    namespace Utils
    {
        /// <summary>
        /// Define an attribute that validate a property againts a white list
        /// Note that currently it only supports int type
        /// </summary>
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
        sealed public class WhiteListAttribute : ValidationAttribute
        {
            /// <summary>
            /// The White List 
            /// </summary>
            public IEnumerable<int> WhiteList
            {
                get;
            }
    
            /// <summary>
            /// The only constructor
            /// </summary>
            /// <param name="whiteList"></param>
            public WhiteListAttribute(params int[] whiteList)
            {
                WhiteList = new List<int>(whiteList);
            }
    
            /// <summary>
            /// Validation occurs here
            /// </summary>
            /// <param name="value">Value to be validate</param>
            /// <returns></returns>
            public override bool IsValid(object value)
            {
                return WhiteList.Contains((int)value);
            }
    
            /// <summary>
            /// Get the proper error message
            /// </summary>
            /// <param name="name">Name of the property that has error</param>
            /// <returns></returns>
            public override string FormatErrorMessage(string name)
            {
                return $"{name} must have one of these values: {String.Join(",", WhiteList)}";
            }
    
        }
    }
