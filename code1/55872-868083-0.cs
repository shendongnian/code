            string path = @"C:\Windows\System32\drivers\etc\hosts";
            string [] lineArray = System.IO.File.ReadAllLines(path);
                
            List<string> lines = blah.ToList();
            string sitetoUNblock = string.Format("127.0.0.1 http://{0}", listView1.SelectedItems[0].Text);
            lines.Remove(sitetoUNblock);
            System.IO.File.WriteAllLines(path, lines.ToArray());
