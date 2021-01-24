    public void UpdateTrippingTariff(List<TrippingTariffTransaction> obj)
        {           
            using (IDbConnection connection = ConnectionManager.Connection)
            {
                string qry = "";
                foreach (var details in obj.ToList())
                {
                    qry = "DECLARE @TripTariffTransactionID as BIGINT;";
                    qry += "SET @TripTariffTransactionID = (SELECT Id FROM [dbo].[TrippingTariffTransaction] WHERE Trip = @Trip AND TrippingDistanceId = @TrippingDistanceId AND TrippingTariffId = @TrippingTariffId);";
                    qry += @" IF (@TripTariffTransactionID != 0) 
                              BEGIN                             
                                  UPDATE [dbo].[TrippingTariffTransaction]
                                        SET
                                        Price = @Price
                                 WHERE Id = @TripTariffTransactionID
                             END
                             
                       ELSE
                            BEGIN
                                INSERT INTO [dbo].[TrippingTariffTransaction]
                                    (TrippingTariffId
                                    ,Trip
                                    ,Price
                                    ,TrippingDistanceId
                                    ,IsActive)
                               VALUES
                                    (@TrippingTariffId
                                    ,@Trip
                                    ,@Price
                                    ,@TrippingDistanceId
                                    ,@IsActive);
                               SET @TripTariffTransactionID = (SELECT CAST(SCOPE_IDENTITY() as BIGINT))
                           END;";
                    qry += @"INSERT INTO [dbo].[TrippingTariffTransactionAuditTrail]
                                (LogDatetime
                                ,MasterlistId
                                ,ComputerName
                                ,TrippingTariffTransactionID
                                ,Activity)
                         VALUES
                                (GETDATE()
                                ,@MasterlistId
                                ,@ComputerName
                                ,@TripTariffTransactionID
                                ,@Activity)";
                    
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    connection.Execute(qry, details);
                    connection.Close();
                }
            }
        }
