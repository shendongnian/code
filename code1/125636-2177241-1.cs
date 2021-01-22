        MemoryStream ms = new MemoryStream();
        using (writer = new XmlTextWriter(ms, System.Text.Encoding.UTF8))
        {
            writePaymentRequest(writer, registrant, amount, signature, ipaddress);
        }
        byte[] bytes = ms.ToArray();
        ms.Close();
        httpWebRequest.GetRequestStream().Write(bytes, 0, bytes.Length);
        httpWebRequest.ContentLength = bytes.Length;
