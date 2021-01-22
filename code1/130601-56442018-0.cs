                     // DECLARATION
                    HttpContext context = HttpContext.Current;
                    DataTable dt_ShoppingBasket = context.Session["Shopping_Basket"] as DataTable;
                    // TRY TO ADD rows with the info into the DataTable
                    try
                    {
                        // Add new Serial Code into DataTable dt_ShoppingBasket
                        dt_ShoppingBasket.Rows.Add(new_SerialCode.ToString());
                        // Assigns new DataTable to Session["Shopping_Basket"]
                        context.Session["Shopping_Basket"] = dt_ShoppingBasket;
                    }
                    catch (Exception)
                    {
                        // IF FAIL (EMPTY OR DOESN'T EXIST) - 
                        // Create new Instance, 
                        DataTable dt_PanierCommande = new DataTable();
                        // Add column and Row with the info
                        dt_PanierCommande.Columns.Add("GenCod");
                        dt_PanierCommande.Rows.Add(new_SerialCode.ToString());
                        // Assigns new DataTable to Session["Shopping_Basket"]
                        context.Session["Shopping_Basket"] = dt_PanierCommande;
                    }
                    // PRINT TESTS
                    DataTable dt_To_Print = context.Session["Shopping_Basket"] as DataTable;
                    foreach (DataRow row in dt_To_Print.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            Debug.WriteLine("DATATABLE IN SESSION: " + item);
                        }
                    }
                    Response.AddHeader("REFRESH", "0.1;URL=misesenvente.aspx");isesenvente.aspx");
