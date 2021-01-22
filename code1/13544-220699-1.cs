        private delegate void PROG_Delegate<TGridLine>(DataGridView dgv, IEnumerable<TGridLine> gridLines, string[] columns);
        public static void PopulateReadOnlyGrid<TGridLine>(DataGridView dgv, IEnumerable<TGridLine> gridLines, string[] columns)
        {
            if (dgv.InvokeRequired)
            {
                dgv.BeginInvoke
                            (
                                new PROG_Delegate<TGridLine>(PopulateReadOnlyGrid<TGridLine>),
                                new object[] { dgv, gridLines, columns }
                            );
            }
            //GridUtils.StatePreserver statePreserver = new GridUtils.StatePreserver(dgv);
            //System.Data.DataTable dt = CollectionHelper.ConvertToDataTable<TGridLine>((gridLines));
            //dgv.DataSource = dt;
            //dgv.DataMember = "";
            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //GridUtils.OrderColumns<TGridLine>(dgv, columns);
            //statePreserver.RestoreState();
            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }
