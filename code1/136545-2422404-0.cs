    private void viewTodoList_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
            {
                if (e.Column == CheckMarkColumn)
                {
                    if (ConditionIsMet())
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
                    }
                }
            }
