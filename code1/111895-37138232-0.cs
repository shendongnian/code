    DataTable dt = curData.loadCurrency();
                var curId = from c in dt.AsEnumerable()
                            where c.Field<bool>("LocalCurrency") == true
                            select c.Field<int>("CURID");
    
                foreach (int cid in curId)
                {
                    txtCURID.Text = cid.ToString();
                }
                var curName = from c in dt.AsEnumerable()
                              where c.Field<bool>("LocalCurrency") == true
                              select c.Field<string>("CurName");
                foreach (string cName in curName)
                {
                    txtCurrency.Text = cName.ToString();
                }
