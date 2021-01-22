        public void DeleteMail(IMAPMessage msg)
        {
            msg.Folder.Select();
            string cmd = "UID STORE {0} +FLAGS (\\Deleted \\Seen)\r\n";
            ArrayList result = new ArrayList();
            SendAndReceive(String.Format(cmd, msg.Uid), ref result);
            int countResult = result.Count - 1;
            while (countResult >= 0)
            {
                if (result[countResult].ToString().ToLower().Contains("ok"))
                {
                    msg.Flags.New = false;
                    msg.Flags.Deleted = true;
                    string cmd2 = "EXPUNGE\r\n";
                    ArrayList result2 = new ArrayList();
                    SendAndReceive(String.Format(cmd2, msg.Uid), ref result2);
                    if (result2[0].ToString().ToLower().Contains("ok"))
                    {
                        //Deu certo!!
                        msg.Folder.Examine();
                    }
                }
                countResult--;
            }
        }
