    if (Opf.ShowDialog() == true)
    {
        using (StreamWriter swa = new StreamWriter(Opf.FileName))
        {
            foreach(ItemViewModal vm in PlayList.Items)
            {
                var ix = vm.Sname + " " + vm.Duration;
                swa.WriteLine(ix);
            }
        }
        MessageBox.Show("List Saved.");
    }
