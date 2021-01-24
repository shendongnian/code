                    RealtimeSample.RealtimeGetOptionalParms param = new RealtimeSample.RealtimeGetOptionalParms();
                    param.Dimensions = "rt:deviceCategory";
                    response = RealtimeSample.Get(svc, "ga:XXXXX", "rt:activeUsers", param);
                    foreach (var row in response.Rows)
                    {
                        foreach (string col in row)
                        {
                            Console.Write(col + " ");  // writes the value of the column
                        }
                        Console.Write("\r\n");
                    }
