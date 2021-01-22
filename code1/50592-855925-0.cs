    public abstract class MultipartRangeHandler : IHttpHandler
    {
        protected const String HEADER_RANGE = "range";
        protected const String HEADER_CONTENT_TYPE = "Content-Type";
        protected const String HEADER_CONTENT_LENGTH = "Content-Length: ";
        protected const String HEADER_CONTENT_DISPOSITION = "Content-Disposition";
        protected const String HEADER_CONTENT_RANGE = "Content-Range";
        protected const String HEADER_BOUNDARY_DELIMETER = "--";
        protected const String HEADER_STATUS_PARTIAL_CONTENT = "Partial Content";
        private const char COMMA = ',';
        private const char EQUALS = '=';
        private const char NEW_LINE = '\n';
        protected const String QS_OBJECT_ID = "cid";
        public void ProcessRequest(HttpContext context)
        {
            if (StringUtils.isNullOrEmpty(context.Request.QueryString[QS_OBJECT_ID]))
            {
                sendResponse(400, "400 Bad Request", "No resource was specified in the query string to retrieve.", context);
            }
            else
            {
                ContentItem contentItem = getContentItem(context.Request.QueryString[QS_OBJECT_ID]);
                if (contentItem != null)
                {
                    context.Response.Clear();
                    context.Response.ClearHeaders();
                    context.Response.ClearContent();
                    if (context.Request.Headers[HEADER_RANGE] != null)
                    {
                        string range = context.Request.Headers[HEADER_RANGE];
                        range = range.Substring(range.LastIndexOf(EQUALS) + 1);
                        bool isMultipartRange = range.Contains(COMMA.ToString());
                        if (!isMultipartRange)
                        {
                            addHeader(context.Response, HEADER_CONTENT_TYPE, contentItem.MimeType);
                            addHeader(context.Response, HEADER_CONTENT_DISPOSITION, "inline; filename=\"" + contentItem.Filename + "\"");
                            string[] startEnd = range.Split('-');
                            long startPos;
                            long.TryParse(startEnd[0], out startPos);
                            long endPos;
                            int fileSize = contentItem.FileBytes.Length;
                            if (startEnd.GetUpperBound(0) >= 1 && startEnd[1] != String.Empty)
                            {
                                long.TryParse(startEnd[1], out endPos);
                            }
                            else
                            {
                                endPos = fileSize - startPos;
                            }
                            if (endPos > fileSize)
                            {
                                endPos = fileSize - startPos;
                            }
                            context.Response.StatusCode = 206;
                            context.Response.StatusDescription = HEADER_STATUS_PARTIAL_CONTENT;
                            addHeader(context.Response, HEADER_CONTENT_RANGE, "bytes " + startPos + "-" + endPos + "/" + fileSize);
                            context.Response.BinaryWrite(ByteUtils.subByte(contentItem.FileBytes, (int)startPos, (int)(endPos - startPos) + 1));
                        }
                        else
                        {
                            string boundary = "waynehartmanansmach";
                            addHeader(context.Response, HEADER_CONTENT_TYPE, "multipart/byteranges; boundary=" + boundary);
                            List<string[]> ranges = new List<string[]>();
                            string[] multiRange = range.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string mr in multiRange)
                            {
                                ranges.Add(mr.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries));
                            }
                            //  process the list of ranges
                            foreach (string[] rangeArray in ranges.ToArray())
                            {
                                context.Response.Write(HEADER_BOUNDARY_DELIMETER + boundary + NEW_LINE);
                                context.Response.Write(HEADER_CONTENT_TYPE + ": " + contentItem.MimeType + NEW_LINE);
                                context.Response.Write(HEADER_CONTENT_RANGE + ": bytes " + rangeArray[0] + "-" + rangeArray[1] + "/" + contentItem.FileBytes + NEW_LINE + NEW_LINE);
                                long startPos = long.Parse(rangeArray[0]);
                                long endPos = long.Parse(rangeArray[1]);
                                context.Response.BinaryWrite(ByteUtils.subByte(contentItem.FileBytes, (int)startPos, (int)(endPos - startPos) + 1));
                                context.Response.Write(NEW_LINE);
                                context.Response.Flush();
                            }
                            context.Response.Write(HEADER_BOUNDARY_DELIMETER + boundary + HEADER_BOUNDARY_DELIMETER + NEW_LINE + NEW_LINE);
                        }
                    }
                    else
                    {
                        context.Response.ContentType = contentItem.MimeType;
                        addHeader(context.Response, HEADER_CONTENT_DISPOSITION, "attachment; filename=\"" + contentItem.Filename + "\"");
                        addHeader(context.Response, HEADER_CONTENT_LENGTH, contentItem.FileBytes.Length.ToString());
                        context.Response.OutputStream.Write(contentItem.FileBytes, 0, contentItem.FileBytes.Length);
                    }
                }
                else
                {
                    sendResponse(404, "404 Not Found", "The resource requested does not exist.", context);                    
                }
            }
        }
        private void sendResponse(int statusCode, String status, String statusMessage, HttpContext context)
        {
            System.Text.StringBuilder data = new System.Text.StringBuilder();
            data.AppendLine("<html><body>");
            data.AppendLine("<h1>"+status+"</h1>");
            data.AppendLine("<p>"+statusMessage+"</p>");
            data.AppendLine("</body></html>");
            byte[] headerData = System.Text.Encoding.ASCII.GetBytes(data.ToString());
            context.Response.ContentType = "text/html";
            context.Response.StatusCode = statusCode;
            context.Response.Status = status;
            addHeader(context.Response, HEADER_CONTENT_LENGTH, headerData.Length.ToString());
            //context.Response.AddHeader("Content-Length: ", headerData.Length.ToString());
            context.Response.OutputStream.Write(headerData, 0, headerData.Length);
            context.Response.End();
        }
        protected void addHeader(HttpResponse response, String key, String value)
        {
            response.AddHeader(key, value);
        }
        protected abstract com.waynehartman.util.web.handlers.multipartrange.ContentItem getContentItem(String objectID);
        public bool IsReusable
        {
            get { return true; }
        }
    }
