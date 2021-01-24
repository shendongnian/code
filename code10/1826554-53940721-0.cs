    using System;
    using System.Windows.Forms;
    public class EditablButton : Button
    {
        private TextBox txt;
        public enum EditModes { OnPressF2, OnClick, Programmatically }
        public EditModes EditMode { get; set; } = EditModes.OnPressF2;
        public bool IsEditing => txt.Visible;
        public EditablButton()
        {
            txt = new TextBox();
            txt.TextAlign = HorizontalAlignment.Center;
            txt.Visible = false;
            txt.Multiline = true;
            txt.Dock = DockStyle.Fill;
            this.Controls.Add(txt);
            txt.KeyDown += Txt_PreviewKeyDown;
        }
        private void Txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                EndEdit();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyData == Keys.Escape)
            {
                CancelEdit();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        public void BeginEdit()
        {
            txt.Text = this.Text;
            txt.SelectAll();
            txt.Visible = true;
            txt.Focus();
        }
        public void EndEdit()
        {
            this.Text = txt.Text;
            txt.Visible = false;
            this.Focus();
        }
        public void CancelEdit()
        {
            txt.Visible = false;
            this.Focus();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!IsEditing && EditMode == EditModes.OnPressF2 && keyData == Keys.F2)
            {
                BeginEdit();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override void OnClick(EventArgs e)
        {
            if (EditMode == EditModes.OnClick)
                BeginEdit();
            else
                base.OnClick(e);
        }
    }
