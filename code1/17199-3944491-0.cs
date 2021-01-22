    public static class ControlExtenders
    {
        /// <summary>
        /// Advanced version of find control.
        /// </summary>
        /// <typeparam name="T">Type of control to find.</typeparam>
        /// <param name="id">Control id to find.</param>
        /// <returns>Control of given type.</returns>
        /// <remarks>
        /// If the control with the given id is not found
        /// a new control instance of the given type is returned.
        /// </remarks>
        public static T FindControl<T>(this Control control, string id) where T : Control
        {
            // User normal FindControl method to get the control
            Control _control = control.FindControl(id);
    
            // If control was found and is of the correct type we return it
            if (_control != null && _control is T)
            {
                // Return new control
                return (T)_control;
            }
    
            // Create new control instance
            _control = (T)Activator.CreateInstance(typeof(T));
    
            // Add control to source control so the
            // next it is found and the value can be
            // passed on itd, remember to hide it and
            // set an ID so it can be found next time
            if (!(_control is ExtenderControlBase))
            {
                _control.Visible = false;
            }
            _control.ID = id;
            control.Controls.Add(_control);
    
            // Use reflection to create a new instance of the control
            return (T)_control;
        }
    }
    
    public static class GenericListExtenders
    {
        /// <summary>
        /// Sorts a generic list by items properties.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="list">Generic list.</param>
        /// <param name="fieldName">Field to sort data on.</param>
        /// <param name="sortDirection">Sort direction.</param>
        /// <remarks>
        /// Use this method when a dinamyc sort field is requiered. If the 
        /// sorting field is known manual sorting might improve performance.
        /// </remarks>
        public static void SortObjects<T>(this List<T> list, string fieldName, SortDirection sortDirection)
        {
            PropertyInfo propInfo = typeof(T).GetProperty(fieldName);
            if (propInfo != null)
            {
                Comparison<T> compare = delegate(T a, T b)
                {
                    bool asc = sortDirection == SortDirection.Ascending;
                    object valueA = asc ? propInfo.GetValue(a, null) : propInfo.GetValue(b, null);
                    object valueB = asc ? propInfo.GetValue(b, null) : propInfo.GetValue(a, null);
                    return valueA is IComparable ? ((IComparable)valueA).CompareTo(valueB) : 0;
                };
                list.Sort(compare);
            }
        }
    
        /// <summary>
        /// Creates a pagged collection from generic list.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="list">Generic list.</param>
        /// <param name="sortField">Field to sort data on.</param>
        /// <param name="sortDirection">Sort direction.</param>
        /// <param name="from">Page from item index.</param>
        /// <param name="to">Page to item index.</param>
        /// <param name="copy">Creates a copy and returns a new list instead of changing the current one.</param>
        /// <returns>Pagged list collection.</returns>
        public static List<T> Page<T>(this List<T> list, string sortField, bool sortDirection, int from, int to, bool copy)
        {
            List<T> _pageList = new List<T>();
    
            // Copy list
            if (copy)
            {
                T[] _arrList = new T[list.Count];
                list.CopyTo(_arrList);
                _pageList = new List<T>(_arrList);
            }
            else
            {
                _pageList = list;
            }
    
            // Make sure there are enough items in the list
            if (from > _pageList.Count)
            {
                int diff = Math.Abs(from - to);
                from = _pageList.Count - diff;
            }
            if (to > _pageList.Count)
            {
                to = _pageList.Count;
            }
    
            // Sort items
            if (!string.IsNullOrEmpty(sortField))
            {
                SortDirection sortDir = SortDirection.Descending;
                if (!sortDirection) sortDir = SortDirection.Ascending;
                _pageList.SortObjects(sortField, sortDir);
            }
    
            // Calculate max number of items per page
            int count = to - from;
            if (from + count > _pageList.Count) count -= (from + count) - _pageList.Count;
    
            // Get max number of items per page
            T[] pagged = new T[count];
            _pageList.CopyTo(from, pagged, 0, count);
    
            // Return pagged items
            return new List<T>(pagged);
        }
    
        /// <summary>
        /// Shuffle's list items.
        /// </summary>
        /// <typeparam name="T">List type.</typeparam>
        /// <param name="list">Generic list.</param>
        public static void Shuffle<T>(this List<T> list)
        {
            Random rng = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                if (swapIndex != i)
                {
                    T tmp = list[swapIndex];
                    list[swapIndex] = list[i];
                    list[i] = tmp;
                }
            }
        }
    
        /// <summary>
        /// Converts generic List to DataTable.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="list">Generic list.</param>
        /// <param name="columns">Name of the columns to copy to the DataTable.</param>
        /// <returns>DataTable.</returns>
        public static DataTable ToDataTable<T>(this List<T> list, string[] columns)
        {
            List<string> _columns = new List<string>(columns);
            DataTable dt = new DataTable();
    
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                if (_columns.Contains(info.Name) || columns == null)
                {
                    dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
                }
            }
            foreach (T t in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo info in typeof(T).GetProperties())
                {
                    if (_columns.Contains(info.Name) || columns == null)
                    {
                        row[info.Name] = info.GetValue(t, null);
                    }
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
    
    public static class DateTimeExtenders
    {
        /// <summary>
        /// Returns number of month from a string representation.
        /// </summary>
        /// <returns>Number of month.</returns>
        public static int MonthToNumber(this DateTime datetime, string month)
        {
            month = month.ToLower();
            for (int i = 1; i <= 12; i++)
            {
                DateTime _dt = DateTime.Parse("1." + i + ".2000");
                string _month = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(i).ToLower();
                if (_month == month)
                {
                    return i;
                }
            }
            return 0;
        }
    
        /// <summary>
        /// Returns month name from month number.
        /// </summary>
        /// <returns>Name of month.</returns>
        public static string MonthToName(this DateTime datetime, int month)
        {
            for (int i = 1; i <= 12; i++)
            {
                if (i == month)
                {
                    return CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(i);
                }
            }
            return "";
        }
    }
    
    public static class ObjectExtender
    {
        public static object CloneBinary<T>(this T originalObject)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, originalObject);
                stream.Position = 0;
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    
        public static object CloneObject(this object obj)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
                binaryFormatter.Serialize(memStream, obj);
                memStream.Position = 0;
                return binaryFormatter.Deserialize(memStream);
            }
        }
    }
    
    public static class StringExtenders
    {
        /// <summary>
        /// Returns string as unit.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>Unit</returns>
        public static Unit ToUnit(this string value)
        {
            // Return empty unit
            if (string.IsNullOrEmpty(value))
                return Unit.Empty;
    
            // Trim value
            value = value.Trim();
    
            // Return pixel unit
            if (value.EndsWith("px"))
            {
                // Set unit type
                string _int = value.Replace("px", "");
    
                // Try parsing to int
                double _val = 0;
                if (!double.TryParse(_int, out _val))
                {
                    // Invalid value
                    return Unit.Empty;
                }
    
                // Return unit
                return new Unit(_val, UnitType.Pixel);
            }
    
            // Return percent unit
            if (value.EndsWith("%"))
            {
                // Set unit type
                string _int = value.Replace("%", "");
    
                // Try parsing to int
                double _val = 0;
                if (!double.TryParse(_int, out _val))
                {
                    // Invalid value
                    return Unit.Empty;
                }
    
                // Return unit
                return new Unit(_val, UnitType.Percentage);
            }
    
            // No match found
            return new Unit();
        }
    
        /// <summary>
        /// Returns alternative string if current string is null or empty.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public static string Alternative(this string str, string alternative)
        {
            if (string.IsNullOrEmpty(str)) return alternative;
            return str;
        }
    
        /// <summary>
        /// Removes all HTML tags from string.
        /// </summary>
        /// <param name="html">String containing HTML tags.</param>
        /// <returns>String with no HTML tags.</returns>
        public static string StripHTML(this string html)
        {
            string nohtml = Regex.Replace(html, "<(.|\n)*?>", "");
            nohtml = nohtml.Replace("\r\n", "").Replace("\n", "").Replace("&nbsp;", "").Trim();
            return nohtml;
        }
    }
