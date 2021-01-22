    using System;
    using GetPropertiesSample.ReportService2010; //This is the WebService Proxy
    using System.Diagnostics;
    using System.Reflection;
    using System.Web.Services.Protocols;
    using System.IO;
    namespace GetPropertiesSample
    {
    class Program
    {
        static void Main(string[] args)
        {
            Get_Properties_of_DataSource_given_The_Path_and_Name_of_the_Report();
        }
        private static void Get_Properties_of_DataSource_given_The_Path_and_Name_of_the_Report()
        {
            try
            {
                // Create a Web service proxy object and set credentials
                ReportingService2010 rs = new ReportingService2010();
                rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
                string reportPathAndName = "/0_Contacts/209_Employee_Telephone_List_Printable";
                DataSource[] dataSources = rs.GetItemDataSources(reportPathAndName);
                DataSource ds = dataSources[0];
                string dsName = ds.Name;
                Debug.Print("----------------------------------------------------");
                Debug.Print("Data Source Name: " + dsName);
                Debug.Print("----------------------------------------------------");
                DataSourceDefinition dsd = (DataSourceDefinition)ds.Item;
                if (dsd != null)
                {
                    //Here is one property
                    string connectionString = dsd.ConnectString;  // <======   HERE is the Connection Strin
                    //Use Reflection to get all the properties :    using System.Reflection;
                    var typeDSD = typeof(DataSourceDefinition);
                    var properties = typeDSD.GetProperties();
                    foreach (PropertyInfo p in properties)
                    {
                        Debug.Print("----------------------------------------------------");
                        Debug.Print(p.Name + ": " + p.GetValue(dsd, null));
                    }
                }
            }
            catch (SoapException e)
            {
                Debug.Print("==============================");
                Debug.Print(e.Detail.OuterXml);
                Debug.Print("==============================");
            }
            catch (Exception e)
            {
                Debug.Print("==============================");
                Debug.Print(e.Message);
                Debug.Print(e.InnerException.ToString());
                Debug.Print(e.ToString());
                Debug.Print("==============================");
            }
        }
     }
