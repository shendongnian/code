                byte[] byteArray = Encoding.UTF8.GetBytes (postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/json";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                //Do a http basic authentication somehow
                string username = "<application key from urban airship>";
                string password = "<master secret from urban airship>"; 
                string usernamePassword = username + ":" + password;
                CredentialCache mycache = new CredentialCache();
                mycache.Add( new Uri( "https://go.urbanairship.com/api/push/" ), "Basic", new NetworkCredential( username, password ) );
                request.Credentials = mycache;
                request.Headers.Add( "Authorization", "Basic " + Convert.ToBase64String( new ASCIIEncoding().GetBytes( usernamePassword ) ) );
                // Get the request stream.
                Stream dataStream = request.GetRequestStream ();
                // Write the data to the request stream.
                dataStream.Write (byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close ();
                // Get the response.
                WebResponse response = request.GetResponse ();
                // Display the status.
                Console.WriteLine (((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream ();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader (dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd ();
                // Display the content.
                Console.WriteLine (responseFromServer);
                // Clean up the streams.
                reader.Close ();
                dataStream.Close ();
                response.Close ();
            }
        }
    }
