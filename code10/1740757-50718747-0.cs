            webRequest.Method = WebRequestMethods.Http.Post;
            //"POST";
            webRequest.Accept= "application/x-www-form-urlencoded"; 
            webRequest.ContentType = "application/x-www-form-urlencoded";
            string requestParams = "method=addSubscriber&first_name=" + txt_fname.Text +"&last_name=" + txt_lname.Text + "&address=" + txt_City.Text + "&postcode=" + txt_POBOX.Text + "&country=Brazil&email=" + txt_email.Text + "&mobile_number=" + txt_cellno.Text + "&package%5Bpackage_uid%5D%5B%5D=live&package%5Bpackage_uid%5D%5B%5D=timeshift&package%5Bvalid_from%5D%5B%5D=" + DateTime.Now.ToString("yyyy-MM-dd") + "&package%5Bvalid_from%5D%5B%5D=" + DateTime.Now.ToString("yyyy-MM-dd") + "&package%5Bduration%5D%5B%5D=" + txtDuration.Text + "&package%5Bduration%5D%5B%5D=" + txtDuration.Text + "";
            webRequest.Headers[HttpRequestHeader.Authorization] = "Basic " + authHeaer;
            byte[] byteArray = Encoding.UTF8.GetBytes(requestParams);
            webRequest.ContentLength = byteArray.Length;
            using (Stream requestStream = webRequest.GetRequestStream())
            {
                requestStream.Write(byteArray, 0, byteArray.Length);
            }
            // Get the response.
            using (WebResponse response = webRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(responseStream,Encoding.UTF8);
                    string Json = rdr.ReadToEnd();
                    
                }
            }
