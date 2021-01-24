	private void button1_Click(object sender, EventArgs e)
	{
		ShowForm(new NewCostumer());
	}
	private void ShowForm(Form newForm)
	{
		List<Form> forms = new List<Form>();
		foreach (Form frm in Application.OpenForms)
		{
			if (!(frm is Costumers))
			{
				forms.Add(frm);
			}
		}
		foreach (Form frm in forms)
		{
			frm.Close();
		}
		newForm.Show();
	}
