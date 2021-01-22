				list=new ListViewItem();
				list.UseItemStyleForSubItems=false;
				list.Text="vinoth";
				list.SubItems.Add("afdsdf");
				list.SubItems.Add("afddfdfdfdsdf");
				list.SubItems.Add("afdsdddsdf");
				listView1.Items.Add(list);
			}
			private void listView1_Click(object sender, System.EventArgs e)
		{
			listView1.SelectedItems[0].SubItems[1].BackColor=Color.Red;
		}
