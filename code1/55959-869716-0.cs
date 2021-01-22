        XDocument xml_input = XDocument.Load(FILE_IN);
            string column_create = "";
            //build a list of all schemas in xml
            var schemas = from s in xml_input.Descendants("schema")
                          select new
                          {
                              schema = s,
                              name = s.Element("name").Value
                          };
            //loop through all schemas
            foreach (var s in schemas)
            {
                //write the schema creation lines
                Console.WriteLine("DROP SCHEMA IF EXISTS " + s.name + ";");
                Console.WriteLine("CREATE SCHEMA " + s.name + ";");
                //build a list of all tables in schema
                var tables = from t in s.schema.Descendants("table")
                             select new
                             {
                                 table = t,
                                 name = t.Element("name").Value,
                                 comment = t.Element("comment").Value,
                                 type = t.Element("type").Value
                             };
                //loop through all tables in schema
                foreach (var t in tables)
                {
                    //write the beginning of the table creation lines
                    Console.WriteLine("CREATE TABLE " + s.name + "." + t.name + " (");
                    //build a list of all columns in the schema
                    var columns = from c in t.table.Descendants("column")
                                  select new
                                  {
                                      name = c.Element("name").Value,
                                      type = c.Element("type").Value,
                                      size = c.Element("size").Value,
                                      comment = c.Element("comment").Value
                                  };
                    //loop through all columns in table
                    foreach (var c in columns)
                    {
                        //build the column creation line
                        column_create = c.name + " " + c.type;
                        if (c.size != null)
                        {
                            column_create += "(" + c.size + ")";
                        }
                        if (c.comment != null)
                        {
                            column_create += " COMMENT '" + c.comment + "'";
                        }
                        column_create += ", ";
                        //write the column creation line
                        Console.WriteLine(column_create);
                    }
                    //write the end of the table creation lines
                    Console.WriteLine(")");
                    if (t.comment != null)
                    {
                        Console.WriteLine("COMMENT '" + t.comment + "'");
                    }
                    if (t.type != null)
                    {
                        Console.WriteLine("TYPE = " + t.type);
                    }
                    Console.WriteLine(";");
                }
            }
