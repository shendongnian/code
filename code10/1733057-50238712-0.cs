    // Maybe it's better to use Dictionary for tmpDeeplinkResult and tmpMsgTxt directly
    var grouppedTmpDeeplinkResult = tmpDeeplinkResult.GroupBy(x => x.MessageId).ToDictionary(g => g.Key, g => g.ToList());
    var grouppedTmpMsgTxt = tmpDeeplinkResult.GroupBy(x => x.MessageId).ToDictionary(g => g.Key, g => g.ToDictionary(x => x.RowNumber, x => x.MessageTxt));
    foreach (var item in tmpMsgResult)
    {
        item.DeepLink = grouppedTmpDeeplinkResult[item.MsgID].Select(s => new ClientMessageDeeplinkResponse
        {
            // ...
        }).ToList();
        item.MsgText = grouppedTmpMsgTxt[item.MsgID];
    }
