    private void SetTextOnMemo(string txt){
        if(Memo.InvokeRequired){
            Memo.Invoke(SetTextOnMemo, txt);
        }
        else{
            Memo.Text = txt;
        }
    }
