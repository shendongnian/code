    private void memoExEdit1_Popup(object sender, EventArgs e) {
        MemoExPopupForm popupForm = (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow as MemoExPopupForm;
        MemoEdit meDirections = popupForm.Controls[2] as MemoEdit;
        meDirections.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(meDirections_EditValueChanging);
    }
    void meDirections_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e) {
        GetRemainingChars(sender);
    }
    public void GetRemainingChars(object sender) {
        TextEdit control = sender as TextEdit;
        int maxChars = control.Properties.MaxLength;
        tipCharacterCounter.ShowHint(control.Text.Length + "/" + maxChars, control, ToolTipLocation.RightBottom);
    }
