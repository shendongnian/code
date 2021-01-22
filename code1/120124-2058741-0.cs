                public void FillGatunek()
                {
                    try
                    {
                        Connection.Open();
                        GatunekDataAdapter = new SqlDataAdapter("SELECT * FROM t_gatunek", Connection);
                        commandBuilder = new SqlCommandBuilder(GatunekDataAdapter);
                        GatunekDataAdapter.FillSchema(DataSetGatunek, SchemaType.Mapped, "t_gatunek");
                        DataSetGatunek.Tables["t_gatunek"].Columns["id_gatunek"].AutoIncrement = true;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            
            public void InsertGatunek(string Gatunek)
            {
                try
                {
                    Connection.Open();
                    DataRow R = DataSetGatunek.Tables["t_gatunek"].NewRow();
                    R["gatunek"] = Gatunek;
                    DataSetGatunek.Tables["t_gatunek"].Rows.Add(R);
                    DataSetGatunek.GetChanges();
                    GatunekDataAdapter.Update(DataSetGatunek, "t_gatunek");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
