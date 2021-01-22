    foreach (var signerInfo in signedCms.SignerInfos)
    {
      foreach (var unsignedAttribute in signerInfo.UnsignedAttributes)
      {
        if (unsignedAttribute.Oid.Value == WinCrypt.szOID_RSA_counterSign)
        {
          foreach (var counterSignInfo in signerInfo.CounterSignerInfos)
          {
            foreach (var signedAttribute in counterSignInfo.SignedAttributes)
            {
              if (signedAttribute.Oid.Value == WinCrypt.szOID_RSA_signingTime)
              {
                Pkcs9SigningTime signingTime = (Pkcs9SigningTime)signedAttribute.Values[0];
                Console.Out.WriteLine("Signing Time UTC: " + signingTime.SigningTime);
              }
            }
          }
          return true;
        }
      }
    }
