        public static bool TryParse<t>(this string Value, out t result)
        {
            return TryParser<t>.TryParse(Value.SafeTrim(), out result);
        }
        private delegate bool TryParseDelegate<t>(string value, out t result);
        private static class TryParser<T>
        {
            private static TryParseDelegate<T> parser;
            static TryParser()
            {
                T value = default(T);
                if (value is Enum)
                    AssignClass<T>(TryParseEnum<T>);
                else if (value is bool || value is bool?)
                    AssignStruct<bool>(bool.TryParse);
                else if (value is byte || value is byte?)
                    AssignStruct<byte>(byte.TryParse);
                else if (value is short || value is short?)
                    AssignStruct<short>(short.TryParse);
                else if (value is char || value is char?)
                    AssignStruct<char>(char.TryParse);
                else if (value is int || value is int?)
                    AssignStruct<int>(int.TryParse);
                else if (value is long || value is long?)
                    AssignStruct<long>(long.TryParse);
                else if (value is sbyte || value is sbyte?)
                    AssignStruct<sbyte>(sbyte.TryParse);
                else if (value is ushort || value is ushort?)
                    AssignStruct<ushort>(ushort.TryParse);
                else if (value is uint || value is uint?)
                    AssignStruct<uint>(uint.TryParse);
                else if (value is ulong || value is ulong?)
                    AssignStruct<ulong>(ulong.TryParse);
                else if (value is decimal || value is decimal?)
                    AssignStruct<decimal>(decimal.TryParse);
                else if (value is float || value is float?)
                    AssignStruct<float>(float.TryParse);
                else if (value is double || value is double?)
                    AssignStruct<double>(double.TryParse);
                else if (value is DateTime || value is DateTime?)
                    AssignStruct<DateTime>(DateTime.TryParse);
                else if (value is TimeSpan || value is TimeSpan?)
                    AssignStruct<TimeSpan>(TimeSpan.TryParse);
                else if (value is Guid || value is Guid?)
                    AssignStruct<Guid>(Guid.TryParse);
                else if (value is Version)
                    AssignClass<Version>(Version.TryParse);
                else if (value is System.Net.IPAddress)
                    AssignClass<System.Net.IPAddress>(System.Net.IPAddress.TryParse);
            }
            private static void AssignStruct<t>(TryParseDelegate<t> del)
                where t: struct
            {
                TryParser<t>.parser = del;
                if (typeof(t).IsGenericType
                    && typeof(t).GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    return;
                }
                AssignClass<t?>(TryParseNullable<t>);
            }
            private static void AssignClass<t>(TryParseDelegate<t> del)
            {
                TryParser<t>.parser = del;
            }
            public static bool TryParse(string Value, out T Result)
            {
                if (parser == null)
                {
                    Result = default(T);
                    return false;
                }
                return parser(Value, out Result);
            }
        }
        private static bool TryParseEnum<t>(this string Value, out t result)
        {
            try
            {
                object temp = Enum.Parse(typeof(t), Value, true);
                if (temp is t)
                {
                    result = (t)temp;
                    return true;
                }
            }
            catch
            {
            }
            result = default(t);
            return false;
        }
        private static bool TryParseNullable<t>(string Value, out t? Result)
            where t: struct
        {
            t temp;
            if (TryParser<t>.TryParse(Value, out temp))
            {
                Result = temp;
                return true;
            }
            else
            {
                Result = null;
                return false;
            }
        }
