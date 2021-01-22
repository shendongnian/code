        /// <summary>
        /// Converts Enum Value to different Enum Value (by Value Name) See https://stackoverflow.com/a/31993512/6500501.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum to convert to.</typeparam>
        /// <param name="source">The source enum to convert from.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static TEnum ConvertTo<TEnum>(this Enum source)
        {
            try
            {
                return (TEnum) Enum.Parse(typeof(TEnum), source.ToString(), ignoreCase: true);
            }
            catch (ArgumentException aex)
            {
                throw new InvalidOperationException
                (
                    $"Could not convert {source.GetType().ToString()} [{source.ToString()}] to {typeof(TEnum).ToString()}", aex
                );
            }
        }
