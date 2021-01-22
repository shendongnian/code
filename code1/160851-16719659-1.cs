        public static bool TryParse<t>(this string Value, out t result)
        {
            return TryParser<t>.TryParse(Value.SafeTrim(), out result);
        }
        private delegate bool TryParseDelegate<t>(string value, out t result);
        private static class TryParser<T>
        {
            private static TryParseDelegate<T> parser;
            // Static constructor:
            static TryParser()
            {
                Type t = typeof(T);
                if (t.IsEnum)
                    AssignClass<T>(TryParseEnum<T>);
                else if (t == typeof(bool) || t == typeof(bool?))
                    AssignStruct<bool>(bool.TryParse);
                else if (t == typeof(byte) || t == typeof(byte?))
                    AssignStruct<byte>(byte.TryParse);
                else if (t == typeof(short) || t == typeof(short?))
                    AssignStruct<short>(short.TryParse);
                else if (t == typeof(char) || t == typeof(char?))
                    AssignStruct<char>(char.TryParse);
                else if (t == typeof(int) || t == typeof(int?))
                    AssignStruct<int>(int.TryParse);
                else if (t == typeof(long) || t == typeof(long?))
                    AssignStruct<long>(long.TryParse);
                else if (t == typeof(sbyte) || t == typeof(sbyte?))
                    AssignStruct<sbyte>(sbyte.TryParse);
                else if (t == typeof(ushort) || t == typeof(ushort?))
                    AssignStruct<ushort>(ushort.TryParse);
                else if (t == typeof(uint) || t == typeof(uint?))
                    AssignStruct<uint>(uint.TryParse);
                else if (t == typeof(ulong) || t == typeof(ulong?))
                    AssignStruct<ulong>(ulong.TryParse);
                else if (t == typeof(decimal) || t == typeof(decimal?))
                    AssignStruct<decimal>(decimal.TryParse);
                else if (t == typeof(float) || t == typeof(float?))
                    AssignStruct<float>(float.TryParse);
                else if (t == typeof(double) || t == typeof(double?))
                    AssignStruct<double>(double.TryParse);
                else if (t == typeof(DateTime) || t == typeof(DateTime?))
                    AssignStruct<DateTime>(DateTime.TryParse);
                else if (t == typeof(TimeSpan) || t == typeof(TimeSpan?))
                    AssignStruct<TimeSpan>(TimeSpan.TryParse);
                else if (t == typeof(Guid) || t == typeof(Guid?))
                    AssignStruct<Guid>(Guid.TryParse);
                else if (t == typeof(Version))
                    AssignClass<Version>(Version.TryParse);
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
