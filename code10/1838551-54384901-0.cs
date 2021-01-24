	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.IO;
	using System.Text;
	using FastMember;
	
	namespace BulkCopyTest
	{
		public class Program
		{
			public static void Main(string[] args)
			{
				const string filePath = "SOME FILE THAT YOU WANT TO LOAD TO A DB";
	
				WriteData(GetData<dynamic>(filePath));
			}
	
			private static void WriteData<T>(IEnumerable<T> data)
			{
				using (var bcp = new SqlBulkCopy(GetConnection(), SqlBulkCopyOptions.TableLock, null))
				using (var reader = ObjectReader.Create(data))
				{
					SetColumnMappings<T>(bcp.ColumnMappings);
					bcp.BulkCopyTimeout = 300;
					bcp.BatchSize = 150000;
					bcp.DestinationTableName = ""; //TODO: Set correct TableName
					bcp.WriteToServer(reader);
				}
			}
	
			private static void SetColumnMappings<T>(SqlBulkCopyColumnMappingCollection mappings)
			{
				//Setup your column mappings
			}
	
	
			private static IEnumerable<T> GetData<T>(string filePath)
			{
				using (var fileStream = File.OpenRead(filePath))
				using (var reader = new StreamReader(fileStream, Encoding.UTF8))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						//TODO: Add actual parsing logic and whatever else is needed to create an instance of T
						yield return Activator.CreateInstance<T>();
					}
				}
			}
	
			private static SqlConnection GetConnection()
			{
				return new SqlConnection(new SqlConnectionStringBuilder
				{
					//TODO: Set Connection information here
				}.ConnectionString);
			}
		}
	}
