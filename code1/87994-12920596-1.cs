                    PropertyInfo column = (new Process()).GetType().GetProperties().Where(x => x.Name == dgvProcessList.Columns[e.ColumnIndex].Name).First();
                if (isSortedASC == true)
                    dgvProcessList.DataSource = ((List<Process>)dgvProcessList.DataSource).OrderByDescending(x => column.GetValue(x, null)).ToList();
                else
                    dgvProcessList.DataSource = ((List<Process>)dgvProcessList.DataSource).OrderBy(x => column.GetValue(x, null)).ToList();
                isSortedASC = !isSortedASC;
                dgvProcessList.ClearSelection();
