    internal static string SendMsg(string CorpID, string Secret, string ParamData, Encoding DataEncode)
        {
            string AccessToken = Token(CorpID, Secret);
            string PostUrl = string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", AccessToken);
            return PostWebRequest(PostUrl, ParamData, DataEncode);
        }
    public static void SendMsg2()
        {
            string sCorpID = "" + PDC.CorpID + "";
            string sSecret = "" + PDC.Secret + "";
            PDC.CONTENT = "Test Message";
            
            string Message = "Test";
            string MsgContent = "{";
            MsgContent += "\"totag\": \"" + PDC.DEPTID + "\",";
            MsgContent += "\"msgtype\": \"text\",";
            MsgContent += "\"agentid\": \"" + PDC.AGENTID + "\",";
            MsgContent += "\"text\": {";
            MsgContent += "  \"content\": \"" + Message + "\"";
            MsgContent += "},";
            MsgContent += "\"safe\":\"0\"";
            MsgContent += "}";
            
            SendMsg(sCorpID, sSecret, MsgContent, Encoding.UTF8);
        }
