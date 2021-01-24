        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.Buffer = true;
            context.Response.AddHeader("content-disposition", "attachment;filename=VehiclePositions.pb");
            context.Response.ContentType = "application/x-protobuf";
            WebRequest req = HttpWebRequest.Create("https://cdn.mbta.com/realtime/VehiclePositions.pb");
            FeedMessage feed = Serializer.Deserialize<FeedMessage>(req.GetResponse().GetResponseStream());
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, feed);
                context.Response.BinaryWrite(ms.ToArray());
                context.Response.End();
            }
        }
