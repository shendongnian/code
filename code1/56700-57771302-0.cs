     private void Form1_Load(object sender, EventArgs e)
        {
            /*
             D:\root\Project1\A\A.pdf
             D:\root\Project1\B\t.pdf
             D:\root\Project2\c.pdf
             */
            List<string> n = new List<string>();
            List<string> kn = new List<string>();
            n = Directory.GetFiles(@"D:\root\", "*.*", SearchOption.AllDirectories).ToList();
            kn = Directory.GetDirectories(@"D:\root\", "*.*", SearchOption.AllDirectories).ToList();
            foreach (var item in kn)
            {
                treeView1.Nodes.Add(item.ToString());
            }
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                n = Directory.GetFiles(treeView1.Nodes[i].Text, "*.*", SearchOption.AllDirectories).ToList();
                for (int zik = 0; zik < n.Count; zik++)
                {
                    treeView1.Nodes[i].Nodes.Add(n[zik].ToString());
                }
            }        
        }
