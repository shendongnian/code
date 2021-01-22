    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    
    public static partial class Helpers
    {
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, object> value, bool selectAll = false)
        {
            return enumerable.ToSelectList(value, value, selectAll);
        }
    
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, object> value, object selectedValue)
        {
            return enumerable.ToSelectList(value, value, new List<object>() { selectedValue });
        }
    
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, object> value, IEnumerable<object> selectedValues)
        {
            return enumerable.ToSelectList(value, value, selectedValues);
        }
    
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, object> value, Func<T, object> text, bool selectAll = false)
        {
            foreach (var f in enumerable.Where(x => x != null))
            {
                yield return new SelectListItem()
                {
                    Value = value(f).ToString(),
                    Text = text(f).ToString(),
                    Selected = selectAll
                };
            }
        }
    
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, object> value, Func<T, object> text, object selectedValue)
        {
            return enumerable.ToSelectList(value, text, new List<object>() { selectedValue });
        }
    
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, object> value, Func<T, object> text, IEnumerable<object> selectedValues)
        {
            var sel = selectedValues != null
                ? selectedValues.Where(x => x != null).ToList().ConvertAll<string>(x => x.ToString())
                : new List<string>();
    
            foreach (var f in enumerable.Where(x => x != null))
            {
                yield return new SelectListItem()
                {
                    Value = value(f).ToString(),
                    Text = text(f).ToString(),
                    Selected = sel.Contains(value(f).ToString())
                };
            }
        }
    }
