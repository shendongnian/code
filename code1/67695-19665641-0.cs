        namespace X.Domain.Model
        {
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            public class StoredProcedureParameter : DomainObject
            {
                public StoredProcedureParameter() { }
                public string StoredProcedure { get; set; }
                public string ProcedureSchema { get; set; }
                public string ProcedureName { get; set; }
                public string ParameterName { get; set; }
                public string ParameterOrder { get; set; }
                public string ParameterMode { get; set; }
                public string SqlDataType { get; set; }
                public Type DataType { get { return this.SqlDataType.ToClrType(); } }
            }
            static class StoredProcedureParameterExtensions
            {
                private static Dictionary<string, Type> Mappings;
                public static StoredProcedureParameterExtensions()
                {
                    Mappings = new Dictionary<string, Type>();
                    Mappings.Add("bigint", typeof(Int64));
                    Mappings.Add("binary", typeof(Byte[]));
                    Mappings.Add("bit", typeof(Boolean));
                    Mappings.Add("char", typeof(String));
                    Mappings.Add("date", typeof(DateTime));
                    Mappings.Add("datetime", typeof(DateTime));
                    Mappings.Add("datetime2", typeof(DateTime));
                    Mappings.Add("datetimeoffset", typeof(DateTimeOffset));
                    Mappings.Add("decimal", typeof(Decimal));
                    Mappings.Add("float", typeof(Double));
                    Mappings.Add("image", typeof(Byte[]));
                    Mappings.Add("int", typeof(Int32));
                    Mappings.Add("money", typeof(Decimal));
                    Mappings.Add("nchar", typeof(String));
                    Mappings.Add("ntext", typeof(String));
                    Mappings.Add("numeric", typeof(Decimal));
                    Mappings.Add("nvarchar", typeof(String));
                    Mappings.Add("real", typeof(Single));
                    Mappings.Add("rowversion", typeof(Byte[]));
                    Mappings.Add("smalldatetime", typeof(DateTime));
                    Mappings.Add("smallint", typeof(Int16));
                    Mappings.Add("smallmoney", typeof(Decimal));
                    Mappings.Add("text", typeof(String));
                    Mappings.Add("time", typeof(TimeSpan));
                    Mappings.Add("timestamp", typeof(Byte[]));
                    Mappings.Add("tinyint", typeof(Byte));
                    Mappings.Add("uniqueidentifier", typeof(Guid));
                    Mappings.Add("varbinary", typeof(Byte[]));
                    Mappings.Add("varchar", typeof(String));
                }
                public static Type ToClrType(this string sqlType)
                {
                    Type datatype = null;
                    if (Mappings.TryGetValue(sqlType, out datatype))
                        return datatype;
                    throw new TypeLoadException(string.Format("Can not load CLR Type from {0}", sqlType));
                }
            }
        }
