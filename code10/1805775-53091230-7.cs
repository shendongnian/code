    private void BtnSendMsg_Click(object sender, EventArgs e)
        {
            string token = MSG.Token(null, null);
            if (!string.IsNullOrEmpty(token))
            {
                PDC.MSGTOKEN = token;
            }
            MSG.SendMsg2();
        }
