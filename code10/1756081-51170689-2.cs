        /// <summary>
        /// Return sum of property - filtered by dates and boolean
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="data">Data collection</param>
        /// <param name="datePropertyName">Name of date property to filter</param>
        /// <param name="countPropertyName">Name of property which you want to sum</param>
        /// <param name="booleanPropertyName">If filter have a some boolean restiction - put there this boolean property name</param>
        /// <param name="booleanPropertyValue">If filter have a some boolean restiction - put there this boolean value to filter</param>
        /// <param name="dateFrom">Your date from restiction</param>
        /// <param name="inequalityFrom">Inequality 'from' sign to filter</param>
        /// <param name="dateTo">Your date to restriction</param>
        /// <param name="inequalityTo">Inequality 'to' sign to filter</param>
        /// <returns>Sum of countPropertyName</returns>
        public double GetFilteredCount<T>(List<T> data, string datePropertyName, string countPropertyName, string booleanPropertyName = null, bool? booleanPropertyValue = null, DateTime? dateFrom = null, Inequality inequalityFrom = Inequality.Undefined, 
            DateTime? dateTo = null, Inequality inequalityTo = Inequality.Undefined)
        {
            double? result = null;
            var list = new List<T>(data);
            if (list != null && list.Count > 0 && !String.IsNullOrEmpty(datePropertyName) && !String.IsNullOrEmpty(countPropertyName) && (inequalityFrom != Inequality.Undefined || inequalityTo != Inequality.Undefined))
            {
                list = list.Where(w =>
                {
                    DateTime value = (DateTime)w.GetType().GetProperty(datePropertyName).GetValue(w);
                    return dateFrom.HasValue ? 
                    (        
                        inequalityFrom == Inequality.GreatherThan ? value > dateFrom :
                        inequalityFrom == Inequality.GreatherOrEqualThan ? value >= dateFrom :
                        inequalityFrom == Inequality.LessThan ? value < dateFrom :
                        inequalityFrom == Inequality.LessOrEqualThan ? value <= dateFrom :
                        inequalityFrom == Inequality.Equal ? value == dateFrom : true
                    ) : true && dateTo.HasValue ? 
                    (
                        inequalityTo == Inequality.GreatherThan ? value > dateTo :
                        inequalityTo == Inequality.GreatherOrEqualThan ? value >= dateTo :
                        inequalityTo == Inequality.LessThan ? value < dateTo :
                        inequalityTo == Inequality.LessOrEqualThan ? value <= dateTo :
                        inequalityTo == Inequality.Equal ? value == dateTo : true
                    ) : true && !String.IsNullOrEmpty(booleanPropertyName) && booleanPropertyValue.HasValue ?
                    (
                        (bool)w.GetType().GetProperty(booleanPropertyName).GetValue(w) == booleanPropertyValue
                    ) : true;
                }).ToList<T>();
                if (list != null && list.Count > 0)
                {
                    result = list.Sum(s => (double?)s.GetType().GetProperty(countPropertyName).GetValue(s));
                }
            }
            return result ?? 0;
        }
