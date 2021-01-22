            // DbConnection connection;
            // string parameterName
            DataRow schema=connection.GetSchema(DbMetaDataCollectionNames.DataSourceInformation).Rows[0];
            string placeholder=string.Format(
                CultureInfo.InvariantCulture,
                (string)schema[DbMetaDataColumnNames.ParameterMarkerFormat],
                name.Substring(0, Math.Min(parameterName.Length, (int)schema[DbMetaDataColumnNames.ParameterNameMaxLength]))
            );
