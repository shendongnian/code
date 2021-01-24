    namespace ConsoleApplication5
    {
    // A struct ot represent an external column
    public struct Column
    {
        public String Name;
        public String SSISDataType;
        public int Length;
        public int Precision;
        public int Scale;
        public int CodePage;
        public Column(String name, String ssisDataType, int length, int precision, int scale, int codePage)
        {
            Name = name;
            SSISDataType = ssisDataType;
            Length = length;
            Precision = precision;
            Scale = scale;
            CodePage = codePage;
        }
    }
    public class Packager
    {
        public Packager()
        {
            build();
        }
        private void build()
        {
            #region Package Related
            // Package related
            Package package = new Package();
            Executable e = package.Executables.Add("STOCK:PipelineTask");
            TaskHost thMainPipe = e as TaskHost;
            MainPipe dataFlowTask = thMainPipe.InnerObject as MainPipe;
            thMainPipe.Name = "MyDFT";
            thMainPipe.DelayValidation = true;
            #endregion
            #region Add Connection Manager
            // Add Connection Manager
            ConnectionManager cm = package.Connections.Add("OLEDB");
            cm.Name = "OLEDB ConnectionManager";
            cm.ConnectionString = "Data Source=(local);" +
              "Initial Catalog=AdventureWorks;Provider=SQLOLEDB.1;" +
              "Integrated Security=SSPI;";
            #endregion
            #region Add a OleDB Source and set up basic properties
            // Add an OLE DB source to the data flow.  
            IDTSComponentMetaData100 component = dataFlowTask.ComponentMetaDataCollection.New();
            component.Name = "OLEDBSource";
            component.ComponentClassID = "Microsoft.OLEDBSource"; // check for the exact component class ID on your machine
            // Get the design time instance of the component.  
            CManagedComponentWrapper instance = component.Instantiate();
            // Initialize the component  
            instance.ProvideComponentProperties();
            // Specify the connection manager.  
            if (component.RuntimeConnectionCollection.Count > 0)
            {
                component.RuntimeConnectionCollection[0].ConnectionManager = DtsConvert.GetExtendedInterface(package.Connections[0]);
                component.RuntimeConnectionCollection[0].ConnectionManagerID = package.Connections[0].ID;
            }
            // Set the custom properties.  
            instance.SetComponentProperty("AccessMode", 2);
            instance.SetComponentProperty("SqlCommand", "Select * from Production.Product");
            #endregion
            #region Core example showcasing use of IDTSExternalMetadataColumn when external data source is not available.
            // Typically here we call acquireconnection, reinitmetadata etc to get the metadata from a data source that exists.
            // Instead we will populate the metadata ourselves
            #region Get External Columns Metadata
            // Get the collection of external columns
            List<Column> externalColumns = new List<Column>();
            // Hard Coding Here. But grab them from your metadata source programmatically.
            Column columnA = new Column("col_a", "DT_STR", 24, 0, 0, 1252);
            Column columnB = new Column("col_b", "DT_STR", 36, 0, 0, 1252);
            Column columnC = new Column("col_c", "DT_STR", 48, 0, 0, 1252);
            externalColumns.Add(columnA);
            externalColumns.Add(columnB);
            externalColumns.Add(columnC);
            #endregion
            #region Add External Columns to our required IDTSOutput100
            // Grab the appropriate output as needed. We will be adding ExternalColumns to this Output
            IDTSOutput100 output = component.OutputCollection[0];
            // Add each external column to the above IDTSOutPut
            foreach (Column extCol in externalColumns)
            {
                IDTSExternalMetadataColumn100 col = output.ExternalMetadataColumnCollection.New();
                col.Name = extCol.Name;
                col.Scale = extCol.Scale;
                col.Precision = extCol.Precision;
                col.Length = extCol.Length;
                col.CodePage = extCol.CodePage;
                col.DataType = (Wrapper.DataType)Enum.Parse(typeof(Wrapper.DataType), extCol.SSISDataType);
            }
            #endregion
            #region Create OutputColumn if it does not exist/or grab the output column if it Exists. Then associate it to the External Column
            // Now associate the External Column to an Output Column.
            // Here, we will simply associate the external column to an output column if the name matches (because of our use case)
            foreach (IDTSExternalMetadataColumn100 extCol in output.ExternalMetadataColumnCollection)
            {
                bool outputColExists = false;
                // Set DataTypes and Associate with external column if output col exists
                foreach (IDTSOutputColumn100 outputCol in output.OutputColumnCollection)
                {
                    if (outputCol.Name == extCol.Name) // is map based on name
                    {
                        // Set the data type properties
                        outputCol.SetDataTypeProperties(extCol.DataType, extCol.Length, extCol.Precision, extCol.Scale, extCol.CodePage);
                        // Associate the external column and the output column
                        outputCol.ExternalMetadataColumnID = extCol.ID;
                        outputColExists = true;
                        break;
                    }
                }
                // Create an IDTSOutputColumn if not exists. 
                if (!(outputColExists))
                {
                    IDTSOutputColumn100 outputCol = output.OutputColumnCollection.New();
                    outputCol.Name = extCol.Name;  // map is based on name
                    // Set the data type properties
                    outputCol.SetDataTypeProperties(extCol.DataType, extCol.Length, extCol.Precision, extCol.Scale, extCol.CodePage);
                    // Associate the external column and the output column
                    outputCol.ExternalMetadataColumnID = extCol.ID;
                }
            }
            #endregion
            #endregion
            #region Save the Package to disk
            new Application().SaveToXml(@"C:\Temp\Pkg.dtsx", package, null);
            #endregion
        }
    }
