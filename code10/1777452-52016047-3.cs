    private void bw_start()
             {
                    // bw = new BackgroundWorker[];                
                    i++;
     
                    //новый поток
                    bw[i] = new BackgroundWorker();
                    bw[i].WorkerReportsProgress = true;
                    bw[i].WorkerSupportsCancellation = true;
     
                    bw[i].DoWork += new DoWorkEventHandler(bw_DoWork); 
                    bw[i].RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted); //обработчик 
                    bw[i].ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                
                    if (bw[i].IsBusy != true)
                    bw[i].RunWorkerAsync();
            }
     
            private void bw_DoWork(object sender, DoWorkEventArgs e)
                {
                    DataTable table_1;
     
                    //привязка данных
                    BindingSource bs;
     
     
                    table_1 = new DataTable();
                    table_1.Columns.Add("Content", typeof(string));
                    table_1.Columns.Add("DateTime", typeof(DateTime));
     
                    bs = new BindingSource(table_1, "");
     
     
                    // Читаем файл "Данные"
                    string[] lines = System.IO.File.ReadAllLines(pathFileData);
     
                    // System.Console.WriteLine("Contents of WriteLines2.txt = ");
                    foreach (string line in lines)
                    {
                        // создаем новую запись
                        DataRow newrow = table_1.NewRow();
     
                        // заполняем ее данными
                        newrow["Content"] = line;
                        newrow["DateTime"] = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
     
                        // заносим запись в таблицу
                        table_1.Rows.Add(newrow);
     
                        // обновляем данные в грид
                        bs.ResetBindings(false);
     
                        // Пауза
                        System.Threading.Thread.Sleep(1500);
                        Application.DoEvents();
                    }
                }
     
            private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
                {
                    
                }
     
            static void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
                {
                    
                }
