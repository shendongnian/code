        private static string GetUploadFilter()
        {
            // Desired format:
            // "Document files (*.doc, *.docx, *.pdf)|*.doc;*.docx;*.pdf|"
            // "Image files (*.bmp, *.jpg)|*.bmp;*.jpg|"
            string filter = String.Empty;
            string nameFilter = String.Empty;
            string extFilter = String.Empty;
            // Used to get extensions
            DataTable dt = new DataTable();
            dt = DataLayer.Get_DataTable("SELECT * FROM FILE_TYPES ORDER BY EXTENSION");
            // Used to cycle through doctype groupings ("Images", "Documents", etc.)
            DataTable dtDocTypes = new DataTable();
            dtDocTypes = DataLayer.Get_DataTable("SELECT DISTINCT DOCTYPE FROM FILE_TYPES ORDER BY DOCTYPE");
            
            // For each doctype grouping...
            foreach (DataRow drDocType in dtDocTypes.Rows)
            {
                nameFilter = drDocType["DOCTYPE"].ToString() + " files (";
                // ... add its associated extensions
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["DOCTYPE"].ToString() == drDocType["DOCTYPE"].ToString())
                    {
                        nameFilter += "*" + dr["EXTENSION"].ToString() + ", ";
                        extFilter += "*" + dr["EXTENSION"].ToString() + ";";
                    }                    
                }
                // Remove endings put in place in case there was another to add, and end them with pipe characters:
                nameFilter = nameFilter.TrimEnd(' ').TrimEnd(',');
                nameFilter += ")|";
                extFilter = extFilter.TrimEnd(';');
                extFilter += "|";
                // Add the name and its extensions to our main filter
                filter += nameFilter + extFilter;
                extFilter = ""; // clear it for next round; nameFilter will be reset to the next DOCTYPE on next pass
            }
            filter = filter.TrimEnd('|');
            return filter;
        }
        private void UploadFile(string fileType, object sender)
        {            
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            string filter = GetUploadFilter();
            dlg.Filter = filter;
            if (dlg.ShowDialog().Value == true)
            {
                string fileName = dlg.FileName;
                System.IO.FileStream fs = System.IO.File.OpenRead(fileName);
                byte[] array = new byte[fs.Length];
                // This will give you just the filename
                fileName = fileName.Split('\\')[fileName.Split('\\').Length - 1];
                ...
