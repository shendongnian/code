    foreach(var One in OnrTwoThree)
                {
                    foreach(var Two in One.Value)
                    {
                       foreach(var rowdetails in dtdetails)
                        {
                            if(Two.Key==rowdetails.RowName)
                            {
                                dt.Rows[rowdetails.RowNumber][One.Key] = Two.Value;
                            }
    
                        }
                    }
                }
