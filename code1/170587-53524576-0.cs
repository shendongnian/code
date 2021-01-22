    namespace SqlServerMetaSearchScan
    {
        using Newtonsoft.Json;
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Data.SqlClient;
        using System.IO;
        using System.Linq;
        using System.Security.Cryptography;
        using System.Text;
        using System.Threading;
        using System.Xml;
    public class Program
    {
        #region Ignition
        public static void Main(string[] args)
        {
            // Defaulting
            SqlConnection connection = null;
            try
            {               
                // Questions
                ColorConsole.Print("SQL Connection String> ");
                string connectionString = Console.ReadLine();
                ColorConsole.Print("Search Term (Case Ignored)> ");
                string searchTerm = Console.ReadLine();
                ColorConsole.Print("Skip Databases (Comma Delimited)> ");
                List<string> skipDatabases = Console.ReadLine().Split(',').Where(item => item.Trim() != string.Empty).ToList();
                // Search
                connection = new SqlConnection(connectionString);
                connection.Open();
                // Each database
                List<string> databases = new List<string>();
                string databasesLookup = "SELECT name FROM master.dbo.sysdatabases";
                SqlDataReader reader = new SqlCommand(databasesLookup, connection).ExecuteReader();
                while (reader.Read())
                {
                    // Capture
                    databases.Add(reader.GetValue(0).ToString());
                }
                // Build quintessential folder
                string logsDirectory = @"E:\Logs";
                if (!Directory.Exists(logsDirectory))
                {
                    // Build
                    Directory.CreateDirectory(logsDirectory);
                }
                string baseFolder = @"E:\Logs\SqlMetaProbeResults";
                if (!Directory.Exists(baseFolder))
                {
                    // Build
                    Directory.CreateDirectory(baseFolder);
                }
                // Close reader
                reader.Close();                
                // Sort databases
                databases.Sort();
                // New space
                Console.WriteLine(Environment.NewLine + " Found " + databases.Count + " Database(s) to Scan" + Environment.NewLine);
                // Deep scan
                foreach (string databaseName in databases)
                {
                    // Skip skip databases
                    if (skipDatabases.Contains(databaseName))
                    {
                        // Skip 
                        continue;
                    }
                    // Select the database
                    new SqlCommand("USE " + databaseName, connection).ExecuteNonQuery();
                    // Table count
                    int tablePosition = 1;
                    try
                    {
                        // Defaulting
                        List<string> tableNames = new List<string>();
                        // Schema examination
                        DataTable table = connection.GetSchema("Tables");
                        // Query tables
                        string tablesLookup = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
                        using (SqlDataReader databaseReader = new SqlCommand(tablesLookup, connection).ExecuteReader())
                        {
                            // Get data
                            while (databaseReader.Read())
                            {
                                // Push
                                if (databaseReader.GetValue(0).ToString().Trim() != string.Empty)
                                {
                                    tableNames.Add(databaseReader.GetValue(0).ToString());
                                }
                            }
                            // Bail
                            databaseReader.Close();
                        }
                        // Sort
                        tableNames.Sort();                        
                        // Cycle tables
                        foreach (string tableName in tableNames)
                        {
                            // Build data housing
                            string databasePathName = @"E:\Logs\\SqlMetaProbeResults" + databaseName;
                            string tableDirectoryPath = @"E:\Logs\SqlMetaProbeResults\" + databaseName + @"\" + tableName;
                            // Count first
                            int totalEntityCount = 0;
                            int currentEntityPosition = 0;                            
                            string countQuery = "SELECT count(*) FROM " + databaseName + ".dbo." + tableName;
                            using (SqlDataReader entityCountReader = new SqlCommand(countQuery, connection).ExecuteReader())
                            {
                                // Query count
                                while (entityCountReader.Read())
                                {
                                    // Capture
                                    totalEntityCount = int.Parse(entityCountReader.GetValue(0).ToString());
                                }
                                // Close
                                entityCountReader.Close();
                            }
                            // Write the objects into the houseing
                            string jsonLookupQuery = "SELECT * FROM " + databaseName + ".dbo." + tableName;
                            using (SqlDataReader tableReader = new SqlCommand(jsonLookupQuery, connection).ExecuteReader())
                            {                                                
                                // Defaulting
                                List<string> fieldValueListing = new List<string>();
                                // Read continue
                                while (tableReader.Read())
                                {                                   
                                    // Increment
                                    currentEntityPosition++;
                                    // Defaulting
                                    string identity = null;
                                    // Gather data
                                    for (int i = 0; i < tableReader.FieldCount; i++)
                                    {
                                        // Set
                                        if (tableReader.GetName(i).ToUpper() == "ID")
                                        {
                                            identity = tableReader.GetValue(0).ToString();
                                        }
                                        else
                                        {
                                            // Build column data entry
                                            string thisColumn = tableReader.GetValue(i) != null ? "'" + tableReader.GetValue(i).ToString().Trim() + "'" : string.Empty;
                                            // Piece
                                            fieldValueListing.Add(thisColumn);
                                        }
                                    }
                                    // Path-centric
                                    string explicitIdentity = identity ?? Guid.NewGuid().ToString().Replace("-", string.Empty).ToLower();
                                    string filePath = tableDirectoryPath + @"\" + "Obj." + explicitIdentity + ".json";
                                    string reStringed = JsonConvert.SerializeObject(fieldValueListing, Newtonsoft.Json.Formatting.Indented);
                                    string percentageMark = ((double)tablePosition / (double)tableNames.Count * 100).ToString("#00.0") + "%";                                                      
                                    string thisMarker = Guid.NewGuid().ToString().Replace("-", string.Empty).ToLower();
                                    string entityPercentMark = string.Empty;
                                    if (totalEntityCount != 0 && currentEntityPosition != 0)
                                    {
                                        // Percent mark
                                        entityPercentMark = ((double)currentEntityPosition / (double)totalEntityCount * 100).ToString("#00.0") + "%";
                                    }
                                    // Search term verify
                                    if (searchTerm.Trim() != string.Empty)
                                    {
                                        // Search term scenario
                                        if (reStringed.ToLower().Trim().Contains(searchTerm.ToLower().Trim()))
                                        {
                                            // Lazy build
                                            if (!Directory.Exists(tableDirectoryPath))
                                            {
                                                // Build
                                                Directory.CreateDirectory(tableDirectoryPath);
                                            }
                                            // Has the term
                                            string idMolding = identity == null || identity == string.Empty ? "No Identity" : identity;
                                            File.WriteAllText(filePath, reStringed);
                                            ColorConsole.Print(percentageMark + " => " + databaseName + "." + tableName + "." + idMolding + "." + thisMarker + " (" + entityPercentMark + ")", ConsoleColor.Green, ConsoleColor.Black, true);
                                        }
                                        else
                                        {
                                            // Show progress                                            
                                            string idMolding = identity == null || identity == string.Empty ? "No Identity" : identity;
                                            ColorConsole.Print(percentageMark + " => " + databaseName + "." + tableName + "." + idMolding + "." + thisMarker + " (" + entityPercentMark + ")", ConsoleColor.Yellow, ConsoleColor.Black, true);
                                        }
                                    }
                                }
                                // Close
                                tableReader.Close();
                            }
                                                                                                  
                            // Increment
                            tablePosition++;
                        }                        
                    }
                    catch (Exception err)
                    {
                        ColorConsole.Print("DB.Tables!: " + err.Message, ConsoleColor.Red, ConsoleColor.White, false);                        
                    }
                }
            }
            catch (Exception err)
            {
                ColorConsole.Print("KABOOM!: " + err.ToString(), ConsoleColor.Red, ConsoleColor.White, false);                
            }
            finally
            {
                try { connection.Close(); }
                catch { }
            }
            // Await
            ColorConsole.Print("Done.");
            Console.ReadLine();
        }
        #endregion
        #region Cores
        public static string GenerateHash(string inputString)
        {
            // Defaulting
            string calculatedChecksum = null;
            // Calculate
            SHA256Managed checksumBuilder = new SHA256Managed();
            string hashString = string.Empty;
            byte[] hashBytes = checksumBuilder.ComputeHash(Encoding.ASCII.GetBytes(inputString));
            foreach (byte theByte in hashBytes)
            {
                hashString += theByte.ToString("x2");
            }
            calculatedChecksum = hashString;
            // Return
            return calculatedChecksum;
        }
        #endregion
        #region Colors
        public class ColorConsole
        {
            #region Defaulting
            public static ConsoleColor DefaultBackground = ConsoleColor.DarkBlue;
            public static ConsoleColor DefaultForeground = ConsoleColor.Yellow;
            public static string DefaultBackPorch = "                                                                              ";
            #endregion
            #region Printer Cores
            public static void Print(string phrase)
            {
                // Use primary
                Print(phrase, DefaultForeground, DefaultBackground, false);
            }
            public static void Print(string phrase, ConsoleColor customForecolor)
            {
                // Use primary
                Print(phrase, customForecolor, DefaultBackground, false);
            }
            public static void Print(string phrase, ConsoleColor customBackcolor, bool inPlace)
            {
                // Use primary
                Print(phrase, DefaultForeground, customBackcolor, inPlace);
            }
            public static void Print(string phrase, ConsoleColor customForecolor, ConsoleColor customBackcolor)
            {
                // Use primary
                Print(phrase, customForecolor, customBackcolor, false);
            }
            public static void Print(string phrase, ConsoleColor customForecolor, ConsoleColor customBackcolor, bool inPlace)
            {
                // Capture settings
                ConsoleColor captureForeground = Console.ForegroundColor;
                ConsoleColor captureBackground = Console.BackgroundColor;
                // Change colors
                Console.ForegroundColor = customForecolor;
                Console.BackgroundColor = customBackcolor;
                // Write
                if (inPlace)
                {
                    // From beginning of this line + padding
                    Console.Write("\r" + phrase + DefaultBackPorch);
                }
                else
                {
                    // Normal write
                    Console.Write(phrase);
                }
                // Revert
                Console.ForegroundColor = captureForeground;
                Console.BackgroundColor = captureBackground;
            }
            #endregion
        }
        #endregion
    }
    }
