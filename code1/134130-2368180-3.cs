    HttpWebRequest lxRequest = (HttpWebRequest)WebRequest.Create(
    "http://www.productimageswebsite.com/images/stock_jpgs/34891.jpg");
    
    // returned values are returned as a stream, then read into a string
    String lsResponse = string.Empty;
    using (HttpWebResponse lxResponse = (HttpWebResponse)lxRequest.GetResponse()){
       using (BinaryReader reader = new BinaryReader(lxResponse.GetResponseStream())) {
          Byte[] lnByte = reader.ReadBytes(1 * 1024 * 1024 * 10);
          using (FileStream lxFS = new FileStream("34891.jpg", FileMode.Create)) {
              lxFS.Write(lnByte, 0, lnByte.Length);
          }
       }
    }
    MessageBox.Show("done");
