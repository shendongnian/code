                    copy.ColumnMappings.Add(0, 0);
                    copy.ColumnMappings.Add(1, 1);
                    copy.ColumnMappings.Add(2, 2);
                    copy.DestinationTableName = "TableNameToMapTo";
                    copy.WriteToServer(dtDistinct );
