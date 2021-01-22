	private void dgvAccount_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
			if (!dgvAccount.Rows[e.RowIndex].Selected)
			{
				dgvAccount.ClearSelection();
				dgvAccount.Rows[e.RowIndex].Selected = true;
			}
	}
	private void dgvAccount_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
	{
		if (e.RowIndex == -1 || e.ColumnIndex == -1)
			return;
		bool isPayment = true;
		bool isCharge = true;
		foreach (DataGridViewRow row in dgvAccount.SelectedRows)
		{
			if ((string)row.Cells["P/C"].Value == "C")
				isPayment = false;
			else if ((string)row.Cells["P/C"].Value == "P")
				isCharge = false;
		}
		if (isPayment)
			e.ContextMenuStrip = cmsAccountPayment;
		else if (isCharge)
			e.ContextMenuStrip = cmsAccountCharge;
	}
	private void tsmiVoidPayment_Click(object sender, EventArgs e)
	{
		int paymentCount = dgvAccount.SelectedRows.Count;
		if (paymentCount == 0)
			return;
		bool voidPayments = false;
		string confirmText = "Are you sure you would like to void this payment?"; // to be localized
		if (paymentCount > 1)
			confirmText = "Are you sure you would like to void these payments?"; // to be localized
		voidPayments = (MessageBox.Show(
						confirmText,
						"Confirm", // to be localized
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Warning,
						MessageBoxDefaultButton.Button2
					   ) == DialogResult.Yes);
		if (voidPayments)
		{
			// SQLTransaction Start
			foreach (DataGridViewRow row in dgvAccount.SelectedRows)
			{
				//do Work    
			}
		}
	}
	private void tsmiDeleteCharge_Click(object sender, EventArgs e)
	{
		int chargeCount = dgvAccount.SelectedRows.Count;
		if (chargeCount == 0)
			return;
		bool deleteCharges = false;
		string confirmText = "Are you sure you would like to delete this charge?"; // to be localized
		if (chargeCount > 1)
			confirmText = "Are you sure you would like to delete these charges?"; // to be localized
		deleteCharges = (MessageBox.Show(
						confirmText,
						"Confirm", // to be localized
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Warning,
						MessageBoxDefaultButton.Button2
					   ) == DialogResult.Yes);
		if (deleteCharges)
		{
			// SQLTransaction Start
			foreach (DataGridViewRow row in dgvAccount.SelectedRows)
			{
				//do Work    
			}
		}
	}
	private void cmsAccountPayment_Opening(object sender, CancelEventArgs e)
	{
		int itemCount = dgvAccount.SelectedRows.Count;
		string voidPaymentText = "&Void Payment"; // to be localized
		if (itemCount > 1)
			voidPaymentText = "&Void Payments"; // to be localized
		if (tsmiVoidPayment.Text != voidPaymentText) // avoid possible flicker
			tsmiVoidPayment.Text = voidPaymentText;
	}
	private void cmsAccountCharge_Opening(object sender, CancelEventArgs e)
	{
		int itemCount = dgvAccount.SelectedRows.Count;
		string deleteChargeText = "&Delete Charge"; //to be localized
		if (itemCount > 1)
			deleteChargeText = "&Delete Charges"; //to be localized
		if (tsmiDeleteCharge.Text != deleteChargeText) // avoid possible flicker
			tsmiDeleteCharge.Text = deleteChargeText;
	}
