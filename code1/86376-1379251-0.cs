    string storeID = "...";
    string queryObject = "...";
    string storeIDCopy = storeID;
    string queryObjectCopy = queryObject;
    Thread t = new Thread(() => StartDNIThread(storeIDCopy, queryObjectCopy));
    t.Start();
    // You can now change storeID and queryObject freely
