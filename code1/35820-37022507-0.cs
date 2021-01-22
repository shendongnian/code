	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Data;
	using System.ComponentModel;
	namespace ConvertListToDataTable
	{
		public static class Program
		{
			public static void Main(string[] args)
			{
				List<MyObject> list = new List<MyObject>();
				for (int i = 0; i < 5; i++)
				{
					list.Add(new MyObject { Sno = i, Name = i.ToString() + "-KarthiK", Dat = DateTime.Now.AddSeconds(i) });
				}
				DataTable dt = ConvertListToDataTable(list);
				foreach (DataRow row in dt.Rows)
				{
					Console.WriteLine();
					for (int x = 0; x < dt.Columns.Count; x++)
					{
						Console.Write(row[x].ToString() + " ");
					}
				}
				Console.ReadLine();
			}
			public class MyObject
			{
				public int Sno { get; set; }
				public string Name { get; set; }
				public DateTime Dat { get; set; }
			}
			public static DataTable ConvertListToDataTable<T>(this List<T> iList)
			{
				DataTable dataTable = new DataTable();
				PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
				for (int i = 0; i < props.Count; i++)
				{
					PropertyDescriptor propertyDescriptor = props[i];
					Type type = propertyDescriptor.PropertyType;
					if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
						type = Nullable.GetUnderlyingType(type);
					dataTable.Columns.Add(propertyDescriptor.Name, type);
				}
				object[] values = new object[props.Count];
				foreach (T iListItem in iList)
				{
					for (int i = 0; i < values.Length; i++)
					{
						values[i] = props[i].GetValue(iListItem);
					}
					dataTable.Rows.Add(values);
				}
				return dataTable;
			}
		}
	}
