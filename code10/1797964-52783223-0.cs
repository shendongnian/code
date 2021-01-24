    public static long saveHeader(ref System.Data.SqlClient.SqlConnection RefConn, Client prst_h)
            {
                long? refInt = 0;
                HRM_TableAdapters.Client_HeaderTableAdapter contTa = new HRM_PrestamosTableAdapters.Client_HTableAdapter();
                contTa.Connection = RefConn;
                if (contTa.Connection.State == ConnectionState.Closed)
                {
                    contTa.Connection.Open();
                }
                System.Data.SqlClient.SqlTransaction trans = contTa.Connection.BeginTransaction("SampleTrans");
                contTa.Transaction = trans;
                try
                {
                    refInt = Convert.ToInt32(contTa.InsertClient_H(prst_h.values));
                    prst_h.DocEntryPRST = (int)refInt.Value;
                    calculateFixedCapFee(ref prst_h);
                    if (prst_h.DetailList.Count > 0)
                    {
                        if (dalPRST_AMORTIZACION.saveDetailList(ref RefConn, prst_h.DetailList, ref trans) != -1)
                        {
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
                            refInt = -1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    string error = ex.Message;
                    refInt = -1;
                }
                finally
                {
                    if (contTa.Connection.State != ConnectionState.Closed)
                    {
                        contTa.Connection.Close();
                    }
                }
                return refInt.Value;
            }
    
    public static long saveClientList(ref System.Data.SqlClient.SqlConnection RefConn, LinkedList<DetailList> prst_DetailList, ref System.Data.SqlClient.SqlTransaction trans)
            {
                long? refInt = 0;
                HRM_TableAdapters.PRST_DetailTableAdapter contTa = new HRM_TableAdapters.PRST_DetailTableAdapter();
                contTa.Connection = RefConn;
                contTa.Transaction = trans;
                try
                {
                    foreach (PRST_Detail prst in prst_DetailList)
                    {
                        refInt = contTa.Insert(prst.Values);
                    }
                }
                catch (System.Exception ex)
                {
                    string error = ex.Message;
                    refInt = -1;
                }
                return refInt.Value;
            }
