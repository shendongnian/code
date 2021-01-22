        foreach (PayObject pay in pays)
        {
           if (pay.IsFirstCheck)
           {
              WriteDetailRowType1(pay);
           }
        }
