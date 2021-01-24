    var dw = DwData(_dwConnectionString);
                var source = SourceData(_sourceConnectionString);
                DataTable prog;
                while (isLoading)
                {
                    System.Threading.Thread.Sleep(1000);
                    dw = DwData(_dwConnectionString);
                    if (dw.Rows.Count > 0)
                    {                     
                        prog = GetProgress(dw, source);
                        if (prog.Rows.Count > 0)
                        {
                            dataGridView1.Invoke(new MethodInvoker(() => { dataGridView1.DataSource = prog; dataGridView1.Refresh(); }));
                        }
                    }
                    
                }
