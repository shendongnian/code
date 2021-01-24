    for(int val = 0; val<dgv.Rows.Count; val++)
                    {
                        if(dgv.Rows[val].Cells[0].Value.ToString()!= "")
                        {
                            FileStream fs = new FileStream(dgv.Rows[val].Cells[0].Value.ToString(), FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);
                            document = br.ReadBytes((Int32)fs.Length);
                            br.Close();
                            fs.Close();
                        }
                    }
