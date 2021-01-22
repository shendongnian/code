      private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            var list = new List<SomeRowType>();
            foreach (StuffObject STUFF in StuffCollection)
            {
                VARIABLE1 = STUFF.SubStuff1.ToString();
                VARIABLE2 = STUFF.SubStuff2.ToString();
                VARIABLE3 = STUFF.SubStuff3.ToString();
                //DatagridWiew1.Rows.Add(VALUE1, VALUE2, VALUE3);
                list.Add(new SomeRowType(VALUE1, VALUE2, VALUE3));  //probably meant: VARIABLEn
            }
            e.Result = list;
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
            }
            else
            {
                var list = (List<SomeRowType>)e.Result;
                DatagridWiew1.DataSource = list;
            }
        }
