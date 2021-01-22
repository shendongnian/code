    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;
    using System.Reflection.Emit;
    using NUnit.Framework;
    
    namespace Salient.Data
    {
        public class DataObj
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    
        [TestFixture]
        public class ListDataReaderFixture
        {
            [Test]
            public void Test()
            {
                var l = new List<DataObj>
                            {
                                new DataObj {Name = "1", Age = 16},
                                new DataObj {Name = "2", Age = 26},
                                new DataObj {Name = "3", Age = 36},
                                new DataObj {Name = "4", Age = 46}
                            };
    
                var r = new ListDataReader<DataObj>(l);
                while (r.Read())
                {
                    Console.WriteLine("Name: {0}, Age: {1}", r.GetValue(0), r.GetValue(1));
                }
            }
        }
    
        public class ListDataReader<T> : IDataReader
        {
            private readonly IList<DynamicProperties.Property> _fields;
            private readonly IList<T> _list;
            private int _fieldCount;
            private int _index;
    
    
            public ListDataReader(IList<T> list)
            {
                _fields = DynamicProperties.CreatePropertyMethods<T>();
                _index = -1;
                _list = list;
            }
    
            #region IDataReader Members
    
            public bool Read()
            {
                return ++_index < _list.Count;
            }
    
            public object GetValue(int i)
            {
                return _fields[i].Getter(_list[_index]);
            }
    
            public int FieldCount
            {
                get { return _fields.Count; }
            }
    
            #endregion
    
            #region NotImplemented
    
            // empty methods derived classes may want to implement
            public virtual int GetOrdinal(string name)
            {
                throw new NotImplementedException();
            }
    
            public virtual void Close()
            {
            }
    
            public virtual void Dispose()
            {
            }
    
            public virtual object this[int i]
            {
                get { throw new NotImplementedException(); }
            }
    
            public virtual int Depth
            {
                get { throw new NotImplementedException(); }
            }
    
            public virtual bool IsClosed
            {
                get { throw new NotImplementedException(); }
            }
    
            public virtual int RecordsAffected
            {
                get { throw new NotImplementedException(); }
            }
    
            public virtual DataTable GetSchemaTable()
            {
                throw new NotImplementedException();
            }
    
            public virtual bool NextResult()
            {
                throw new NotImplementedException();
            }
    
            public virtual object this[string name]
            {
                get { throw new NotImplementedException(); }
            }
    
            public virtual bool GetBoolean(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual byte GetByte(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
            {
                throw new NotImplementedException();
            }
    
            public virtual char GetChar(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
            {
                throw new NotImplementedException();
            }
    
            public virtual IDataReader GetData(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual string GetDataTypeName(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual DateTime GetDateTime(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual decimal GetDecimal(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual double GetDouble(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual Type GetFieldType(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual float GetFloat(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual Guid GetGuid(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual short GetInt16(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual int GetInt32(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual long GetInt64(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual string GetName(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual string GetString(int i)
            {
                throw new NotImplementedException();
            }
    
            public virtual int GetValues(object[] values)
            {
                throw new NotImplementedException();
            }
    
            public virtual bool IsDBNull(int i)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    
    
        /// <summary>
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
        }
    }
