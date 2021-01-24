    private void btnOpenFile_Click(object sender, RoutedEventArgs e)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.slxm";
                    if (openFileDialog.ShowDialog() == true)
                    {
                        xlApp = new Microsoft.Office.Interop.Excel.Application();
                        xlWorkbook = xlApp.Workbooks.Open(openFileDialog.FileName);
        
                        //populate TagListData
                        TagListData.Add(new TagClass { IsTagSelected = true, TagName = "Tag Name 1" });
                    }
        
                    TagList.ItemsSource = TagListData;
                }
