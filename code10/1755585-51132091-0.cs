	private void BrisiBtn_Click(object sender, EventArgs e)
	{
		if (tabelaIsplakaci.CurrentCell != null)
		{
			if (MessageBox.Show("Дали сакате да го избришите овој запис? ", "Избриши запис", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				cIsplakciPrimaci currentIsplakac = lstIsplakaci[tabelaIsplakaci.CurrentCell.RowIndex];
				DeleteIsplakaci(currentIsplakac);
			}
			else
			{
				MessageBox.Show("Записот не е избришан! ", "Избриши запис", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		else { MessageBox.Show("Не постои ниеден запис!"); }
	}
	
	private void Isplakaci_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Delete)
		{
			DeleteIsplakaci(currentIsplakac);
		}
	}
	
	private void DeleteIsplakaci(cIsplakciPrimaci currentIsplakac)
	{
		IPDB.DeleteIsplakac(currentIsplakac, ZiroSmetkaObj);
		MessageBox.Show("Записот е избришан!");
		tabelaIsplakaci.Rows.RemoveAt(tabelaIsplakaci.CurrentCell.RowIndex);
		ReadIsplakaci();
	}
