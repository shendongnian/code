    private void memContactWith_Properties_Popup(object sender, EventArgs e)
    {
       MemoExPopupForm popupForm = (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow as MemoExPopupForm;
       MemoEdit me = popupForm.Controls[2] as MemoEdit;
       me.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(me_EditValueChanging);            
    }
    void me_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
    {
       var memo = (sender as MemoEdit);
       var maxChars = memo.Properties.MaxLength;
       lblContactWithCharCount.Text = memo.Text.Length + "/" + maxChars;
    }
