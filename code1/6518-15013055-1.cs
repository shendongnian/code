		public static Boolean InputQuery(String caption, String prompt, ref String value)
		{
			Form form;
			form = new Form();
			form.AutoScaleMode = AutoScaleMode.Font;
			form.Font = SystemFonts.IconTitleFont;
			SizeF dialogUnits;
			dialogUnits = form.AutoScaleDimensions;
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.MinimizeBox = false;
			form.MaximizeBox = false;
			form.Text = caption;
			form.ClientSize = new Size(
						Toolkit.MulDiv(180, dialogUnits.Width, 4),
						Toolkit.MulDiv(63, dialogUnits.Height, 8));
			form.StartPosition = FormStartPosition.CenterScreen;
			System.Windows.Forms.Label lblPrompt;
			lblPrompt = new System.Windows.Forms.Label();
			lblPrompt.Parent = form;
			lblPrompt.AutoSize = true;
			lblPrompt.Left = Toolkit.MulDiv(8, dialogUnits.Width, 4);
			lblPrompt.Top = Toolkit.MulDiv(8, dialogUnits.Height, 8);
			lblPrompt.Text = prompt;
			System.Windows.Forms.TextBox edInput;
			edInput = new System.Windows.Forms.TextBox();
			edInput.Parent = form;
			edInput.Left = lblPrompt.Left;
			edInput.Top = Toolkit.MulDiv(19, dialogUnits.Height, 8);
			edInput.Width = Toolkit.MulDiv(164, dialogUnits.Width, 4);
			edInput.Text = value;
			edInput.SelectAll();
			int buttonTop = Toolkit.MulDiv(41, dialogUnits.Height, 8);
			//Command buttons should be 50x14 dlus
			Size buttonSize = Toolkit.ScaleSize(new Size(50, 14), dialogUnits.Width / 4, dialogUnits.Height / 8);
			System.Windows.Forms.Button bbOk = new System.Windows.Forms.Button();
			bbOk.Parent = form;
			bbOk.Text = "OK";
			bbOk.DialogResult = DialogResult.OK;
			form.AcceptButton = bbOk;
			bbOk.Location = new Point(Toolkit.MulDiv(38, dialogUnits.Width, 4), buttonTop);
			bbOk.Size = buttonSize;
			System.Windows.Forms.Button bbCancel = new System.Windows.Forms.Button();
			bbCancel.Parent = form;
			bbCancel.Text = "Cancel";
			bbCancel.DialogResult = DialogResult.Cancel;
			form.CancelButton = bbCancel;
			bbCancel.Location = new Point(Toolkit.MulDiv(92, dialogUnits.Width, 4), buttonTop);
			bbCancel.Size = buttonSize;
			if (form.ShowDialog() == DialogResult.OK)
			{
				value = edInput.Text;
				return true;
			}
			else
			{
				return false;
			}
		}
