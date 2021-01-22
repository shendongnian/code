	using System;
	using System.Collections.Generic;
	using NHibernate;
	using NHibernate.Persister.Entity;
	namespace Stackoverflow.Example
	{
		/// <summary>
		/// NHibernate helper class
		/// </summary>
		/// <remarks>
		/// Assumes you are using NHibernate version 3.1.0.4000 or greater
		/// </remarks>
		public class NHibernateHelper
		{
			/// <summary>
			/// Gets the list of database column names for an entity
			/// </summary>
			/// <param name="sessionFactory">NHibernate SessionFactory</param>
			/// <param name="entity">A mapped entity</param>
			/// <returns>List of column names</returns>
			public static List<string> GetPropertyColumnNames(ISessionFactory sessionFactory, object entity)
			{
				Type type = entity.GetType();
				// This has some cool methods and properties so check it out
				var metaData = sessionFactory.GetClassMetadata(type.ToString());
				// This has some even cooler methods and properties so definitely check this out
				var entityPersister = (AbstractEntityPersister) metaData;
				var propertyNames = entityPersister.PropertyNames;
				List<string> columnNames = new List<string>();
				foreach (var propertyName in propertyNames)
				{
					var columnName = entityPersister.GetPropertyColumnNames(propertyName);
					columnNames.Add(columnName.Length != 0 ? columnName[0] : null);
				}
				return columnNames;
			}
		}
	}
