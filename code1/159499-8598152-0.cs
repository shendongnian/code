    PROPPATCHResponse = (System.Net.HttpWebResponse)PROPPATCHRequest.GetResponse();
    PROPPATCHResponse.Close();  //<-- Invoke Close Method
    
    PUTResponse1 = (System.Net.HttpWebResponse)PUTRequest1.GetResponse();
    PUTResponse1.Close();       //<-- Invoke Close Method
