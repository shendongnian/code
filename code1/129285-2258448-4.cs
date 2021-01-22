    // <copyright project="Salient.Data" file="ListDataReader.cs" company="Sky Sanders">
    // This source is a Public Domain Dedication.
    // Please see http://spikes.codeplex.com/ for details.   
    // Attribution is appreciated
    // </copyright> 
    // <version>1.0</version>
    
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Salient.Reflection;
    
    namespace Salient.Data
    {
        public class ListDataReader<T> : IDataReader
        {
            private bool _closed;
            private int _fieldCount;
            private IList<DynamicProperties.Property> _fields;
            private int _index;
            private IList<T> _list;
            private int[] _readCount;
    
            public ListDataReader(IList<T> list)
            {
                _closed = false;
                _fields = DynamicProperties.CreatePropertyMethods<T>();
                _index = -1;
                _list = list;
            }
    
            #region IDataReader Members
    
            public bool Read()
            {
                // to keep track of bytes and chars read
                _readCount = new int[_fields.Count];
                return ++_index < _list.Count;
            }
    
            public object GetValue(int i)
            {
                if (i < 0 || i >= _fields.Count)
                {
                    throw new IndexOutOfRangeException();
                }
    
                return _fields[i].Getter(_list[_index]);
            }
    
            public int FieldCount
            {
                get { return _fields.Count; }
            }
    
            public virtual int GetOrdinal(string name)
            {
                for (int i = 0; i < _fields.Count; i++)
                {
                    if (_fields[i].Info.Name == name)
                    {
                        return i;
                    }
                }
    
                throw new IndexOutOfRangeException("name");
            }
    
            public virtual void Close()
            {
                _closed = true;
            }
    
            public virtual void Dispose()
            {
                _fields = null;
                _list = null;
            }
    
            public virtual object this[int i]
            {
                get { return GetValue(i); }
            }
    
    
            public virtual bool IsClosed
            {
                get { return _closed; }
            }
    
            public virtual int RecordsAffected
            {
                get
                {
                    // assuming select only?
                    return -1;
                }
            }
    
            public virtual bool GetBoolean(int i)
            {
                return (Boolean) GetValue(i);
            }
    
            public virtual byte GetByte(int i)
            {
                return (Byte) GetValue(i);
            }
    
    
            public virtual char GetChar(int i)
            {
                return (Char) GetValue(i);
            }
    
    
            public virtual DateTime GetDateTime(int i)
            {
                return (DateTime) GetValue(i);
            }
    
            public virtual decimal GetDecimal(int i)
            {
                return (Decimal) GetValue(i);
            }
    
            public virtual double GetDouble(int i)
            {
                return (Double) GetValue(i);
            }
    
            public virtual Type GetFieldType(int i)
            {
                return _fields[i].Info.PropertyType;
            }
    
            public virtual float GetFloat(int i)
            {
                return (float) GetValue(i);
            }
    
            public virtual Guid GetGuid(int i)
            {
                return (Guid) GetValue(i);
            }
    
            public virtual short GetInt16(int i)
            {
                return (Int16) GetValue(i);
            }
    
            public virtual int GetInt32(int i)
            {
                return (Int32) GetValue(i);
            }
    
            public virtual long GetInt64(int i)
            {
                return (Int64) GetValue(i);
            }
    
    
            public virtual string GetString(int i)
            {
                return (string) GetValue(i);
            }
    
    
            public virtual bool IsDBNull(int i)
            {
                return GetValue(i) == null;
            }
    
    
            public virtual object this[string name]
            {
                get { return GetValue(GetOrdinal(name)); }
            }
    
    
            public virtual DataTable GetSchemaTable()
            {
                var dt = new DataTable();
                foreach (DynamicProperties.Property field in _fields)
                {
                    dt.Columns.Add(new DataColumn(field.Info.Name, field.Info.PropertyType));
                }
                return dt;
            }
    
    
            /// <summary>
            /// Override this to return db specific types
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public virtual string GetDataTypeName(int i)
            {
                return GetFieldType(i).Name;
            }
    
    
            public virtual string GetName(int i)
            {
                if (i < 0 || i >= _fields.Count)
                {
                    throw new IndexOutOfRangeException("name");
                }
                return _fields[i].Info.Name;
            }
    
            public virtual int GetValues(object[] values)
            {
                int i = 0;
                for (; i < _fields.Count; i++)
                {
                    if (values.Length <= i)
                    {
                        return i;
                    }
                    values[i] = GetValue(i);
                }
                return i;
            }
    
            #endregion
    
            #region NotImplemented 6
    
            public virtual bool NextResult()
            {
                throw new NotImplementedException();
            }
    
            public virtual int Depth
            {
                get { throw new NotImplementedException(); }
            }
    
            public virtual IDataReader GetData(int i)
            {
                // need to think about this one
                throw new NotImplementedException();
            }
    
            public virtual long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
            {
                // need to keep track of the bytes got for each record - more work than i want to do right now
                // http://msdn.microsoft.com/en-us/library/system.data.idatarecord.getbytes.aspx
                throw new NotImplementedException();
            }
    
            public virtual long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
            {
                // need to keep track of the bytes got for each record - more work than i want to do right now
                // http://msdn.microsoft.com/en-us/library/system.data.idatarecord.getchars.aspx
                throw new NotImplementedException();
            }
    
            #endregion
        }
    }
--------------------------------------------
    // <copyright project="Salient.Reflection" file="DynamicProperties.cs" company="Sky Sanders">
    // This source is a Public Domain Dedication.
    // Please see http://spikes.codeplex.com/ for details.   
    // Attribution is appreciated
    // </copyright> 
    // <version>1.0</version>
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;
    
    namespace Salient.Reflection
    {
        /// <summary>
        /// Gets IL setters and getters for a property.
        /// 
        /// started with http://jachman.wordpress.com/2006/08/22/2000-faster-using-dynamic-method-calls/
        /// </summary>
        public static class DynamicProperties
        {
            #region Delegates
    
            public delegate object GenericGetter(object target);
    
            public delegate void GenericSetter(object target, object value);
    
            #endregion
    
            public static IList<Property> CreatePropertyMethods<T>()
            {
                var returnValue = new List<Property>();
    
                foreach (PropertyInfo prop in typeof (T).GetProperties())
                {
                    returnValue.Add(new Property(prop));
                }
                return returnValue;
            }
    
    
            /// <summary>
            /// Creates a dynamic setter for the property
            /// </summary>
            /// <param name="propertyInfo"></param>
            /// <returns></returns>
            public static GenericSetter CreateSetMethod(PropertyInfo propertyInfo)
            {
                /*
                * If there's no setter return null
                */
                MethodInfo setMethod = propertyInfo.GetSetMethod();
                if (setMethod == null)
                    return null;
    
                /*
                * Create the dynamic method
                */
                var arguments = new Type[2];
                arguments[0] = arguments[1] = typeof (object);
    
                var setter = new DynamicMethod(
                    String.Concat("_Set", propertyInfo.Name, "_"),
                    typeof (void), arguments, propertyInfo.DeclaringType);
                ILGenerator generator = setter.GetILGenerator();
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Castclass, propertyInfo.DeclaringType);
                generator.Emit(OpCodes.Ldarg_1);
    
                if (propertyInfo.PropertyType.IsClass)
                    generator.Emit(OpCodes.Castclass, propertyInfo.PropertyType);
                else
                    generator.Emit(OpCodes.Unbox_Any, propertyInfo.PropertyType);
    
                generator.EmitCall(OpCodes.Callvirt, setMethod, null);
                generator.Emit(OpCodes.Ret);
    
                /*
                * Create the delegate and return it
                */
                return (GenericSetter) setter.CreateDelegate(typeof (GenericSetter));
            }
    
    
            /// <summary>
            /// Creates a dynamic getter for the property
            /// </summary>
            /// <param name="propertyInfo"></param>
            /// <returns></returns>
            public static GenericGetter CreateGetMethod(PropertyInfo propertyInfo)
            {
                /*
                * If there's no getter return null
                */
                MethodInfo getMethod = propertyInfo.GetGetMethod();
                if (getMethod == null)
                    return null;
    
                /*
                * Create the dynamic method
                */
                var arguments = new Type[1];
                arguments[0] = typeof (object);
    
                var getter = new DynamicMethod(
                    String.Concat("_Get", propertyInfo.Name, "_"),
                    typeof (object), arguments, propertyInfo.DeclaringType);
                ILGenerator generator = getter.GetILGenerator();
                generator.DeclareLocal(typeof (object));
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Castclass, propertyInfo.DeclaringType);
                generator.EmitCall(OpCodes.Callvirt, getMethod, null);
    
                if (!propertyInfo.PropertyType.IsClass)
                    generator.Emit(OpCodes.Box, propertyInfo.PropertyType);
    
                generator.Emit(OpCodes.Ret);
    
                /*
                * Create the delegate and return it
                */
                return (GenericGetter) getter.CreateDelegate(typeof (GenericGetter));
            }
    
            #region Nested type: Property
    
            public class Property
            {
                public GenericGetter Getter;
                public PropertyInfo Info;
                public GenericSetter Setter;
    
                public Property(PropertyInfo info)
                {
                    Info = info;
                    Setter = CreateSetMethod(info);
                    Getter = CreateGetMethod(info);
                }
            }
    
            #endregion
    
            ///// <summary>
            ///// An expression based Getter getter found in comments. untested.
            ///// Q: i don't see a reciprocal setter expression?
            ///// </summary>
            ///// <typeparam name="T"></typeparam>
            ///// <param name="propName"></param>
            ///// <returns></returns>
            //public static Func<T> CreateGetPropValue<T>(string propName)
            //{
            //    var param = Expression.Parameter(typeof(object), "container");
            //    var func = Expression.Lambda(
            //    Expression.Convert(Expression.PropertyOrField(Expression.Convert(param, typeof(T)), propName), typeof(object)), param);
            //    return (Func<T>)func.Compile();
            //}
        }
    }
