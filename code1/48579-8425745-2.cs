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
		/// Assumes you are using NHibernate version 3.1.0.4000 or greater (Not tested on previous versions)
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
				var entityPersister = (AbstractEntityPersister)metaData;
				// Get the entity's identifier
				string entityIdentifier = metaData.IdentifierPropertyName;
				// Get the database identifier
				// Note: We are only getting the first key column.
				// Adjust this code to your needs if you are using composite keys!
				string databaseIdentifier = entityPersister.KeyColumnNames[0];
				var propertyNames = entityPersister.PropertyNames;
				List<string> columnNames = new List<string>();
				// Adding the database identifier first
				columnNames.Add( databaseIdentifier );
				foreach (var propertyName in propertyNames)
				{
					var columnNameArray = entityPersister.GetPropertyColumnNames(propertyName);
					
					foreach (var column in columnNameArray)
					{
						// Filtering out junk
						if (column != databaseIdentifier)
						{
							columnNames.Add(column);
						}
					}
				}
				return columnNames;
			}
		}
	}	
