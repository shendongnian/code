        private void dgvJournal_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset)
            {
                var a = (DataGridView)sender;
                var b = a.DataSource;
                var c = (BindingSource)b;
                var d = c.List;
                int sumDebit = 0, sumCredit = 0;
                int cnt = 0;
                foreach (JournalAccountViewModel account in d)
                {
                    dgvJournal.Rows[cnt].Cells[ColAccountName.Name].Value = accountList.Where(acc => acc.ID == account.AccountID).FirstOrDefault().Name;
                    enableCell(((DataGridViewCell)dgvJournal.Rows[cnt].Cells[ColDebit.Name]), (account.Debit > 0));
                    enableCell(((DataGridViewCell)dgvJournal.Rows[cnt].Cells[colCredit.Name]), (account.Credit > 0));
                    cnt++;
                }
            }
        }
