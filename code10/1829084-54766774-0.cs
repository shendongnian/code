      // establishing the connection
      HttpWebRequest oHttpWebRequest = (HttpWebRequest) WebRequest.Create ("myHttpAddress");
      #if partialDownload
      // reading the range 1000-2000 of the data
      oHttpWebRequest.AddRange (1000, 2000);
      // creating the file
      FileInfo oFileInfo = new FileInfo ("myFilename");
      FileStream oFileStream = oFileInfo.Create ();
      #else
      // reading after the last received byte
      FileInfo oFileInfo = new FileInfo ("myFilename");
      oHttpWebRequest.AddRange (oFileInfo.Length);
      // opening the file for appending the data
      FileStream oFileStream = File.Open (oFileInfo.FullName, FileMode.Append);
      #endif
      // opening the connection
      HttpWebResponse oHttpWebResponse = (HttpWebResponse) oHttpWebRequest.GetResponse ();
      Stream oReceiveStream = oHttpWebResponse.GetResponseStream ();
      // reading the HTML stream and writing into the file
      byte [] abBuffer = new byte [1000000];
      int iReceived = oReceiveStream.Read (abBuffer, 0, abBuffer.Length);
      while ( iReceived > 0 )
      { 
        oFileStream.Write (abBuffer, 0, iReceived);
        iReceived = oReceiveStream.Read (abBuffer, 0, abBuffer.Length);
      };
      // closing and disposing the resources
      oFileStream     .Close   ();
      oFileStream     .Dispose ();
      oReceiveStream  .Close   ();
      oReceiveStream  .Dispose ();
      oHttpWebResponse.Close   ();
      oHttpWebResponse.Dispose ();
