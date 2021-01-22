            DbfDotNet.Linq.DbfTable<DbfDotNet.DbfRecord> dbftable = new DbfDotNet.Linq.DbfTable<DbfDotNet.DbfRecord>(@"ADRESSER.dbf", System.Text.Encoding.ASCII, DbfDotNet.DbfVersion.dBaseIII);
            // Fill grid:
            dbfTableView1.DbfTable = dbftable;
            var distinctPostalCodes = (from row in dbftable.AsEnumerable()
                                       select new
                                       {
                                           code = row.GetField(4),
                                           name = row.GetField(5)
                                       }).OrderBy(x => x.code).Distinct();
            this.comboBox1.DataSource = distinctPostalCodes.ToArray();
            this.comboBox1.DisplayMember = "code";
            this.comboBox1.ValueMember = "code";
