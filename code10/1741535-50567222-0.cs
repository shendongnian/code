    public override void CreateNewOutputRows()
    {
    
        const char FIELD_DEMIMITER = ';';
        ////*** change this to the zero-based index of the problem field
        const int BAD_FIELD_INDEX = 1;
    
        ////*** change this to the connection added to script componenent connection manager
        var filePath = this.Connections.FlatFileSource.ConnectionString; 
    
        string record = "";
        using (var inputFile = new System.IO.StreamReader(filePath))
        {
            record = inputFile.ReadLine();
            if(record != null)
            {
                //count header record fields to get expected field count for data records
                var headerFieldCount = record.Split(FIELD_DEMIMITER).Length;
                while (record != null)
                {
    
                    record = inputFile.ReadLine();
                    if(record == null)
                    {
                        break; //end of file
                    }
    
                    var fields = record.Split(FIELD_DEMIMITER);
                    var extraFieldCount = fields.Length - headerFieldCount;
                    if (extraFieldCount < 0)
                    {
                        //raise an error if fewer fields that we expect
                        throw new DataException(string.Format("Invalid record. {0} fields read, {1} fields in header.", fields.Length, headerFieldCount));
                    }
    
                    if (extraFieldCount > 0)
                    {
    
                        var newFields = new string[headerFieldCount];
                        //copy preceding good fields
                        for (var i = 0; i < BAD_FIELD_INDEX; ++i)
                        {
                            newFields[i] = fields[i];
                        }
    
                        //combine segments of bad field into single field
                        var sourceFieldIndex = BAD_FIELD_INDEX;
                        var combinedField = new System.Text.StringBuilder();
                        while (sourceFieldIndex <= extraFieldCount + BAD_FIELD_INDEX)
                        {
                            combinedField.Append(fields[sourceFieldIndex]);
                            if(sourceFieldIndex < extraFieldCount + BAD_FIELD_INDEX)
                            {
                                combinedField.Append(FIELD_DEMIMITER); //add delimiter back to field value
                            }
                            ++sourceFieldIndex;
                        }
                        newFields[BAD_FIELD_INDEX] = combinedField.ToString();
    
                        //copy subsquent good fields
                        var targetFieldIndex = BAD_FIELD_INDEX + 1;
                        while (sourceFieldIndex < fields.Length)
                        {
                            newFields[targetFieldIndex] = fields[sourceFieldIndex];
                            ++sourceFieldIndex;
                            ++targetFieldIndex;
                        }
                        fields = newFields;
                    }
    
                    //create output record and copy fields
                    this.Output0Buffer.AddRow();
                    //*** change the code below to map source fields to the columns defined as script component output
                    Output0Buffer.ID = fields[0];
                    Output0Buffer.DESCRIPTION = fields[1];
                    Output0Buffer.VALUE = fields[2];
    
                }
            }
    
        }
                
        this.Output0Buffer.SetEndOfRowset();
    
    }
