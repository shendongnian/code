    string receiptData = "(receipt bytes here)";
    
    string url = "https://buy.itunes.apple.com/verifyReceipt";
    
    HttpWebRequest oneWebRequest = (HttpWebRequest)WebRequest.Create(url);
    oneWebRequest.Method = "POST";
    oneWebRequest.ContentType = "application/json; charset=utf-8";
    
    string json = "{ \"receipt-data\": \"" + receiptData + "\" }";
    
    oneWebRequest.ContentLength = json.Length;
    using (System.IO.StreamWriter oneStreamWriter =
      new System.IO.StreamWriter(oneWebRequest.GetRequestStream(),
                                 System.Text.Encoding.ASCII))
    {
        oneStreamWriter.Write(json);
    }
    
    HttpWebResponse oneWebResponse = (HttpWebResponse)oneWebRequest.GetResponse();
    
    // ReceiptStatus is a class with two public string properties (status & receipt)
    DataContractJsonSerializer oneDataContractJsonSerializer =
      new DataContractJsonSerializer(typeof(List<Product>));
    ReceiptStatus oneReceiptStatus =
       (ReceiptStatus) oneDataContractJsonSerializer.ReadObject(
          oneWebResponse.GetResponseStream()
       );
