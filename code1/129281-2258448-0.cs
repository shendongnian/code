    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;
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
            private readonly PropertyInfo[] _fields;
            private readonly IList<T> _list;
            private int _fieldCount;
            private int _index;
    
            public ListDataReader(IList<T> list)
            {
                _index = -1;
                _list = list;
                _fields = typeof (T).GetProperties();
            }
    
            #region IDataReader Members
    
            public bool Read()
            {
                return ++_index < _list.Count;
            }
    
            public object GetValue(int i)
            {
                return _fields[i].GetValue(_list[_index], null);
            }
    
            public int FieldCount
            {
                get { return _fields.Length; }
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
    }
