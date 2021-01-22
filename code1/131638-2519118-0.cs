    public void BTN_ClearAttachment_Clicked(object sender, ClickedEventArgs e)
    {
       try
       {
           _OriginalAttachment.ReplaceSelf("<my:OriginalAttachment></my:OriginalAttachment>");
       }
       catch (Exception ex)
       {
           _ErrorField.SetValue(ex.Message + " : " + ex.StackTrace);
       }
    }
