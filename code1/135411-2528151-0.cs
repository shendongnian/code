    class Program
    {
        public static void Main()
        {
            /*
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("https://go.urbanairship.com/api/push/");
            request.Credentials = new NetworkCredential("application key", "master secret");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array. 
            string postData = "{\"aps\": {\"badge\": 1, \"alert\": \"Hello from Urban Airship!\"}, \"device_tokens\": [\"6334c016fc643baa340eca25bc661d15055a07b475e9a6108f3f641115dd05ac\"]}";
            //string postData = "{\"device_tokens\": [\"6334c016fc643baa340eca25bc661d15055a07b475e9a6108f3344b15dd05ac\"],\"aps\": {\"badge\": 10,\"alert\": \"Hello from Urban Airship!\",\"sound\": \"cat.caf\"}}";
            
            
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
            */
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("https://go.urbanairship.com/api/push/");
            request.Credentials = new NetworkCredential("pvYMExk3QIO7p2YUs6BBkg", "rO3DsucETRadbbfxHkd6qw");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            //WRITE JSON DATA TO VARIABLE D
            string postData = "{\"aps\": {\"badge\": 1, \"alert\": \"Hello from Urban Airship!\"}, \"device_tokens\": [\"6334c016fc643baa340eca25bc661d15055a07b475e9a6108f3f644b15dd05ac\"]}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            //            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}
