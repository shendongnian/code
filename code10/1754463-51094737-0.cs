                var _request = new QueryRequest
                {
                    TableName = "Attendence",
                    KeyConditionExpression = "Roster_EmpID = :Roster_EmpID",// and Roster_Date between :v_start and :v_end",
                    FilterExpression = "Roster_Date between :v_start and :v_end",
                    ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                        {":Roster_EmpID", new AttributeValue {  S = result.empId    }}
                        ,{":v_start", new AttributeValue {   S = result.fromDate.ToString(AWSSDKUtils.ISO8601DateFormat)  }}
                       ,{":v_end", new AttributeValue { S = result.toDate.ToString(AWSSDKUtils.ISO8601DateFormat)    }}
                    },
                    IndexName = "Roster_EmpID-index"
                };
