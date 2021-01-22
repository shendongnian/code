            li = listView1.GetItemAt(e.X, e.Y);
            X = e.X;
            Y = e.Y;
        }
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            int nStart = X;
            int spos = 0;
            int epos = listView1.Columns[1].Width;
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                if (nStart > spos && nStart < epos)
                {
                    subItemSelected = i;
                    break;
                }
                spos = epos;
                epos += listView1.Columns[i].Width;
            }
            li.SubItems[subItemSelected].Text = "9";
        }
