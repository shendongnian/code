	public class StrawberryForm : Form
	{
		private int _invStrawberry = 0;
		private int InvStrawberry
		{
			get
			{
				return _invStrawberry;
			}
			set
			{
				_invStrawberry = value;
				button7.Enabled = _invStrawberry > 0;
			}
		}
		
		private void button7_Click(object sender, EventArgs e)
		{
			int qty = Convert.ToInt32(nudQuantity.Value);
			if ((rdoSmallCup.Checked & rdoStraw.Checked) == true)
			{
				this.InvStrawberry -= 4 * qty;
				label17.Text = Convert.ToString(this.InvStrawberry);
			}
		}
	}
