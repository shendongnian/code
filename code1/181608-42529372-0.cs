    using System;
    using System.Web.Mvc;
    using System.Reflection;
    using System.Collections;
    using System.Collections.Generic;
    namespace MvcApplication1
    {
     public class ArrayOrListParameterAttribute : ActionFilterAttribute
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the list or array parameter.
        /// </summary>
        /// <value>The name of the list or array parameter.</value>
        private string ListOrArrayParameterName { get; set; }
       
        /// <summary>
        /// Gets or sets the separator.
        /// </summary>
        /// <value>The separator.</value>
        private string Separator { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayOrListParameterAttribute"/> class.
        /// </summary>
        /// <param name="listOrArrayParameterName">Name of the list or array parameter.</param>
        public ArrayOrListParameterAttribute(string listOrArrayParameterName) : this(listOrArrayParameterName, ",")
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayOrListParameterAttribute"/> class.
        /// </summary>
        /// <param name="listOrArrayParameterName">Name of the list or array parameter.</param>
        /// <param name="separator">The separator.</param>
        public ArrayOrListParameterAttribute(string listOrArrayParameterName, string separator)
        {
            ListOrArrayParameterName = listOrArrayParameterName;
            Separator = separator;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Called when [action executing].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string separatedValues = filterContext.RouteData.GetRequiredString(ListOrArrayParameterName);
            ParameterInfo[] parameters = filterContext.ActionMethod.GetParameters();
            ParameterInfo searchedParameter = Array.Find(parameters, parameter => parameter.Name == ListOrArrayParameterName);
            if (searchedParameter == null)
                throw new InvalidOperationException(string.Format("Could not find Parameter '{0}' in action method '{1}'", ListOrArrayParameterName, filterContext.ActionMethod.Name));
            Type arrayOrGenericListType = searchedParameter.ParameterType;
            if (!IsTypeArrayOrIList(arrayOrGenericListType))
                throw new ArgumentException("arrayOrIListType is not an array or a type implementing Ilist or IList<>: " + arrayOrGenericListType);
            filterContext.ActionParameters[ListOrArrayParameterName] = GetArrayOrGenericListInstance(arrayOrGenericListType, separatedValues, Separator);
            base.OnActionExecuting(filterContext);
        }
        #endregion
        #region Non Public Methods
        private static bool IsTypeArrayOrIList(Type type)
        {
            if (type.IsArray)
                return true;
            return (Array.Exists(type.GetInterfaces(), x => x == typeof(IList) || x == typeof(IList<>)));
        }
        private static object GetArrayOrGenericListInstance(Type arrayOrIListType, string separatedValues, string separator)
        {
            if (separatedValues == null)
                return null;
            if (separator == null)
                throw new ArgumentNullException("separator");
            if (arrayOrIListType.IsArray)
            {
                Type arrayElementType = arrayOrIListType.GetElementType();
                ArrayList valueList = GetValueList(separatedValues, separator, arrayElementType);
                return valueList.ToArray(arrayElementType);
            }
            Type listElementType = GetListElementType(arrayOrIListType);
            if (listElementType != null)
                return GetGenericIListInstance(arrayOrIListType, GetValueList(separatedValues, separator, listElementType));
            throw new InvalidOperationException("The type could not be handled, this should never happen: " + arrayOrIListType);
        }
        private static Type GetListElementType(Type genericListType)
        {
            Type listElementType = null;
            
            foreach (Type type in genericListType.GetInterfaces())
            {
                if (type.IsGenericType && type == typeof(IList<>).MakeGenericType(type.GetGenericArguments()[0]))
                {
                    listElementType = type.GetGenericArguments()[0];
                    break;
                }
            }
            return listElementType;
        }
        private static object GetGenericIListInstance(Type arrayOrIListType, ArrayList valueList)
        {
            object result = Activator.CreateInstance(arrayOrIListType);
            const BindingFlags flags = BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public;
            foreach (object value in valueList)
            {
                arrayOrIListType.InvokeMember("Add", flags, null, result, new[] { value });
            }
            return result;
        }
        private static ArrayList GetValueList(string separatedValues, string separator, Type memberType)
        {
            string[] values = separatedValues.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            ArrayList valueList = new ArrayList();
            foreach (string value in values)
            {
                valueList.Add(Convert.ChangeType(value, memberType));
            }
            return valueList;
        }
        #endregion
    }
}
