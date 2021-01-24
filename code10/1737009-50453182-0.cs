    int ll_count = -1;    
                var caminho = Directory.GetCurrentDirectory();
                caminho += "\\telefones.txt";
                if (MessageBox.Show("Deseja mesmo deletar o numero?", "Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string[] lines = File.ReadAllLines(caminho);
                    using (StreamWriter writer = new StreamWriter(caminho))
                    {
    
                        foreach (string line in lines)
                        {
                            ll_count++;
    
                            if (ll_count != listView1.SelectedIndices[0])
                            {
                                writer.WriteLine(line);
                            }
                        }
                    }
    
                    listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
