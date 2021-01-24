    using System;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    namespace RestSharpClient
    {
    class RestClientDB
    {
        public static void AddJSONInfo(ChildGetSet jResult)
        {
            bool debugging = false;
            SqlConnection connection = Connection.GetConnection();
            connection.Open();
            try
            {
                ///Check to see if the orderID already exists in the database
                string check = @"(SELECT COUNT(*) FROM OrdersSubTable WHERE FOrderID='" + jResult.FOrderID + "' AND OrderItemID='" +
                    jResult.OrderItemID + "')";
                SqlCommand cmda = new SqlCommand(check, connection);
                int count = (int)cmda.ExecuteScalar();
                if (debugging == true)
                {
                    MessageBox.Show("count: " + count);
                }
                if (count > 0)
                {
                    //MessageBox.Show("Order number: " + Convert.ToString(jResult.FOrderID) + " already exists with Item Number: " + jResult.OrderItemID + ".");
                    
                    SqlCommand update = new SqlCommand("UPDATE OrdersSubTable SET FOrderStatus=@FOrderStatus, OrderItemID=@OrderItemID, " +
                        "ItemState=@ItemState, PartNumber=@PartNumber, Warehouse=@Warehouse, Description=@Description, Quantity=@Quantity, " +
                        "SubtotalTaxAmount=@SubtotalTaxAmount, SubtotalGross=@SubtotalGross, RetailPrice=@RetailPrice, MfgOfferPrice=@MfgOfferPrice, " +
                        "LineDiscount=@LineDiscount, Shipping=@Shipping, ActualPrice=@ActualPrice, Code=@Code, SingleUseCode=@SingleUseCode, " +
                        "Amount=@Amount, IsInventory=@IsInventory, IsGift=@IsGift, IsExternalPayment=@IsExternalPayment " +
                        "Where FOrderID=" + jResult.FOrderID + " AND OrderItemID=" +
                    jResult.OrderItemID, connection);
                    update.Parameters.AddWithValue(
                        "@FOrderStatus", jResult.FOrderStatus);
                    update.Parameters.AddWithValue(
                        "@OrderItemID", jResult.OrderItemID);
                    update.Parameters.AddWithValue(
                        "@ItemState", jResult.ItemState);
                    update.Parameters.AddWithValue(
                        "@PartNumber", jResult.PartNumber);
                    update.Parameters.AddWithValue(
                        "@Warehouse", jResult.Warehouse);
                    update.Parameters.AddWithValue(
                        "@Description", jResult.Description);
                    update.Parameters.AddWithValue(
                        "@Quantity", jResult.Quantity);
                    update.Parameters.AddWithValue(
                        "@SubtotalTaxAmount", jResult.SubtotalTaxAmount);
                    update.Parameters.AddWithValue(
                        "@SubtotalGross", jResult.SubtotalGross);
                    update.Parameters.AddWithValue(
                        "@RetailPrice", jResult.RetailPrice);
                    update.Parameters.AddWithValue(
                        "@MfgOfferPrice", jResult.MfgOfferPrice);
                    update.Parameters.AddWithValue(
                        "@LineDiscount", jResult.LineDiscount);
                    update.Parameters.AddWithValue(
                        "@Shipping", jResult.Shipping);
                    update.Parameters.AddWithValue(
                        "@ActualPrice", jResult.ActualPrice);
                    update.Parameters.AddWithValue(
                            "@Code", jResult.Code);
                    update.Parameters.AddWithValue(
                            "@SingleUseCode", jResult.SingleUseCode);
                    update.Parameters.AddWithValue(
                            "@Amount", jResult.Amount);
                    update.Parameters.AddWithValue(
                            "@IsInventory", jResult.IsInventory);
                    update.Parameters.AddWithValue(
                            "@IsGift", jResult.IsGift);
                    update.Parameters.AddWithValue(
                            "@IsExternalPayment", jResult.IsExternalPayment);
                    update.ExecuteNonQuery();
                    if (debugging == true)
                    {
                        MessageBox.Show("If " + jResult.FOrderStatus + " is different, then it would have changed.");
                    }
                }
                else
                {
                    string insertStatement2 =
                        "INSERT INTO OrdersSubTable " +
                        "(FOrderID, FOrderStatus, OrderItemID, " +
                        "ItemState, PartNumber, Warehouse, Description, Quantity, SubtotalTaxAmount, " +
                        "SubtotalGross, RetailPrice, MfgOfferPrice, LineDiscount, Shipping, ActualPrice, Code, SingleUseCode, Amount, " +
                        "IsInventory, IsGift, IsExternalPayment) " + "VALUES (@FOrderID, @FOrderStatus, " +
                        "@OrderItemID, " +
                        "@ItemState, @PartNumber, @Warehouse, @Description, @Quantity, @SubtotalTaxAmount, " +
                        "@SubtotalGross, @RetailPrice, @MfgOfferPrice, @LineDiscount, @Shipping, @ActualPrice, @Code, @SingleUseCode, " +
                        "@Amount, @IsInventory, @IsGift, @IsExternalPayment)";
                    SqlCommand insertCommand2 =
                       new SqlCommand(insertStatement2, connection);
                    insertCommand2.Parameters.AddWithValue(
                        "@FOrderID", jResult.FOrderID);
                    insertCommand2.Parameters.AddWithValue(
                        "@FOrderStatus", jResult.FOrderStatus);
                    insertCommand2.Parameters.AddWithValue(
                        "@OrderItemID", jResult.OrderItemID);
                    insertCommand2.Parameters.AddWithValue(
                        "@ItemState", jResult.ItemState);
                    insertCommand2.Parameters.AddWithValue(
                        "@PartNumber", jResult.PartNumber);
                    insertCommand2.Parameters.AddWithValue(
                        "@Warehouse", jResult.Warehouse);
                    insertCommand2.Parameters.AddWithValue(
                        "@Description", jResult.Description);
                    insertCommand2.Parameters.AddWithValue(
                        "@Quantity", jResult.Quantity);
                    insertCommand2.Parameters.AddWithValue(
                        "@SubtotalTaxAmount", jResult.SubtotalTaxAmount);
                    insertCommand2.Parameters.AddWithValue(
                        "@SubtotalGross", jResult.SubtotalGross);
                    insertCommand2.Parameters.AddWithValue(
                        "@RetailPrice", jResult.RetailPrice);
                    insertCommand2.Parameters.AddWithValue(
                        "@MfgOfferPrice", jResult.MfgOfferPrice);
                    insertCommand2.Parameters.AddWithValue(
                        "@LineDiscount", jResult.LineDiscount);
                    insertCommand2.Parameters.AddWithValue(
                        "@Shipping", jResult.Shipping);
                    insertCommand2.Parameters.AddWithValue(
                        "@ActualPrice", jResult.ActualPrice);
                    insertCommand2.Parameters.AddWithValue(
                            "@Code", jResult.Code);
                    insertCommand2.Parameters.AddWithValue(
                            "@SingleUseCode", jResult.SingleUseCode);
                    insertCommand2.Parameters.AddWithValue(
                            "@Amount", jResult.Amount);
                    insertCommand2.Parameters.AddWithValue(
                            "@IsInventory", jResult.IsInventory);
                    insertCommand2.Parameters.AddWithValue(
                            "@IsGift", jResult.IsGift);
                    insertCommand2.Parameters.AddWithValue(
                            "@IsExternalPayment", jResult.IsExternalPayment);
                    insertCommand2.ExecuteNonQuery();
                    //MessageBox.Show("Data Successfully written to database.");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (debugging == true)
                    {
                        MessageBox.Show("Violation of primary/unique key. Exception number: " + ex);
                    }
                }
                else
                {
                    if (debugging == true)
                    {
                        MessageBox.Show("SQL Exception number: " + ex);
                    }
                }
            }
            connection.Close();
        }
    }
    }
