            if (nBytesRead > 0)
            {
                 // Translate data bytes to an ASCII string and append
                 sbReceivedData.Append(Encoding.UTF8.GetString(abBuffer, 0, nBytesRead));
                if (bTurboMode)
                {
                      break;
                }
                else
                {
                      // decrease read timeout to nReadTimeoutMS second now that data is coming in
                      oNetworkStream.ReadTimeout = nReadTimeoutMS;
                }
            }
                
