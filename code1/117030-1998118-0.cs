     void Transform(IMyBase t, IPrintLogic printLogic)
     {
        t.Inc();
        printLogic.Print(t);
     }
