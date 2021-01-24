    var directMessages = db.DirectMessages.ToList();
    
    foreach (long r in Recipients)
                    {
                        MsgObj = new AllMsgsClass();
    
                        MsgObj.LastMsg = directMessages.Where(a => (a.SenderID == r || a.RecipientID == r)).OrderByDescending(a => a.CreatedDate).AsNoTracking().FirstOrDefault();
    
                        try
                        {
                            if (MsgObj.LastMsg.MsgSort == "Sent")
                                MsgObj.LastMsg.RecipientProfileImageUrl = "https://avatars.io/twitter/" + MsgObj.LastMsg.RecipientScreenName + "/small";
    
                            else
                                MsgObj.LastMsg.SenderProfileImageUrl = "https://avatars.io/twitter/" + MsgObj.LastMsg.SenderScreenName + "/small";
                        }
                        catch (Exception dd)
                        {
                            string x = dd.Message;
                        }
    
                        MsgObj.SortOrder = Convert.ToDateTime(MsgObj.LastMsg.CreatedDate);
                        AllMSGsList.Add(MsgObj);
                    }
