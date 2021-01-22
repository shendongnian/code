     public DataSet parseIIF(Stream file) {
                iifSet = new DataSet();
                String fileText;
    
                using (StreamReader sr = new StreamReader(file)) {
                    fileText = sr.ReadToEnd();
                }
                //replace line breaks with tabs
                //fileText.Replace('\n', '\t');
                fileText = fileText.Replace("\r\n", "\n");
                fileText = fileText.Replace('\r', '\n');
    
                //split along tabs
                string[] lines = fileText.Split('\n');
    
                this.createTables(lines, iifSet);
                this.fillSet(lines, iifSet);
    
                return iifSet;
            }
    
            /// <summary>
            /// Reads an array of lines and parses them into tables for the dataset
            /// </summary>
            /// <param name="lines">String Array of lines from the iif file</param>
            /// <param name="iifSet">DataSet to be manipulated</param>
            private void fillSet(string[] lines, DataSet set) {
                //CODING HORROR
                //WARNING: I will monkey with the for loop index, be prepared!
                for (int i = 0; i < lines.Length; i++) {
                    if (this.isTableHeader(lines[i])) {
                        //ignore this line, tables are alread defined
                        continue;
                    }
                    if (lines[i] == "" || lines[i] == "\r" || lines[i] == "\n\r" || lines[i] == "\n") {
                        //ignore lines that are empty if not inside a record
                        //probably the end of the file, it always ends with a blank line break
                        continue;
                    }
    
                    if (lines[i].IndexOf(";__IMPORTED__") != -1) {
                        continue;
                        //just signifying that it's been imported by quickbook's timer before, don't need it
                    }
    
                    string line = lines[i];
                    while (!isFullLine(line, set)){
                        i++;            //<--------------------------- MONKEYING done here!
                        line += lines[i];       
                    }
                    //now, the line should be complete, we can parse it by tabs now
                    this.parseRecord(line, set);
                }
            }
    
            private void parseRecord(string line, DataSet set) {
                if (isTableHeader(line)) {
                    //we don't want to deal with headers here
                    return;
                }
    
                String tablename = line.Split('\t')[0];
                //this just removes the first value and the line break from the last value
                String[] parameters = this.createDataRowParams(line);
    
                //add it to the dataset
                set.Tables[tablename].Rows.Add(parameters);
            }
    
            private bool isFullLine(string line, DataSet set) {
                if (isTableHeader(line)) {
                    return true;    //assumes table headers won't have line breaks
                }
                int values = line.Split('\t').Length;
                string tableName = line.Split('\t')[0];
                int columns = set.Tables[tableName].Columns.Count;
    
                if (values < columns) {
                    return false;
                } else {
                    return true;
                }
            }
    
            private void createTables(string[] lines, DataSet set) {
                for (int index = 0; index < lines.Length; index++) {
                    if (this.isTableHeader(lines[index])) {
                        set.Tables.Add(createTable(lines[index]));
                    }
                }
            }
    
            private bool isTableHeader(string tab) {
                if (tab.StartsWith("!"))
                    return true;
                else
                    return false;
            }
    
            private bool isNewLine(string p) {
                if (p.StartsWith("!"))
                    return true;
                if (iifSet.Tables[p.Split('\t')[0]] != null)    //that little mess there grabs the first record in the line, sorry about the mess
                    return true;
                return false;
            }
        private DataTable createTable(string line) {
            String[] values = line.Split('\t');
            //first value is always the title
            //remove the ! from it
            values[0] = values[0].Substring(1);     //remove the first character
            DataTable dt = new DataTable(values[0]);
            values[0] = null;   //hide first title so it doesn't get used, cheaper than resetting array
            foreach (String name in values) {
                if (name == null || name == "")
                    continue;
                DataColumn dc = new DataColumn(name, typeof(String));
                try {
                    dt.Columns.Add(dc);
                } catch (DuplicateNameException) {
                    //odd
                    dc = new DataColumn(name + "_duplicateCol" + dt.Columns.Count.ToString());
                    dt.Columns.Add(dc);
                    //if there is a triple, just throw it
                }
            }
            return dt;
        }
       private string getTableName(string line) {
            String[] values = line.Split('\t');
            //first value is always the title
            if(values[0].StartsWith("!")){
                //remove the ! from it
                values[0] = values[0].Substring(1);     //remove the first character
            }
            return values[0];
        }
        private string[] createDataRowParams(string line) {
            string[] raw = line.Split('\t');
            string[] values = new string[raw.Length - 1];
            //copy all values except the first one
            for (int i = 0; i < values.Length; i++) {
                values[i] = raw[i + 1];
            }
            //remove last line break from the record
            if (values[values.Length - 1].EndsWith("\n")) {
                values[values.Length - 1] = values[values.Length - 1].Substring(0, values[values.Length - 1].LastIndexOf('\n'));
            } else if (values[values.Length - 1].EndsWith("\n\r")) {
                values[values.Length - 1] = values[values.Length - 1].Substring(0, values[values.Length - 1].LastIndexOf("\n\r"));
            } else if (values[values.Length - 1].EndsWith("\r")) {
                values[values.Length - 1] = values[values.Length - 1].Substring(0, values[values.Length - 1].LastIndexOf('\r'));
            }
            return values;
        }
        private string[] createDataRowParams(string line, int max) {
            string[] raw = line.Split('\t');
            int length = raw.Length - 1;
            if (length > max) {
                length = max;
            }
            string[] values = new string[length];
            for (int i = 0; i < length; i++) {
                values[i] = raw[i + 1];
            }
            if (values[values.Length - 1].EndsWith("\n")) {
                values[values.Length - 1] = values[values.Length - 1].Substring(0, values[values.Length - 1].LastIndexOf('\n'));
            } else if (values[values.Length - 1].EndsWith("\n\r")) {
                values[values.Length - 1] = values[values.Length - 1].Substring(0, values[values.Length - 1].LastIndexOf("\n\r"));
            } else if (values[values.Length - 1].EndsWith("\r")) {
                values[values.Length - 1] = values[values.Length - 1].Substring(0, values[values.Length - 1].LastIndexOf('\r'));
            }
            return values;
        }
