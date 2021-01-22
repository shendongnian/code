            catch (WebException ex)
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)ex.Response;
                String details = "NONE";
                String statusCode = "NONE";
                if (httpWebResponse != null)
                {
                    details = httpWebResponse.StatusDescription;
                    statusCode = httpWebResponse.StatusCode.ToString();
                }
                Response.Clear();
                Response.Write(ex.Message);
                Response.Write("<BR />");
                Response.Write(ex.Status);
                Response.Write("<BR />");
                Response.Write(statusCode);
                Response.Write("<BR />");
                Response.Write(details);
                Response.Write("<BR />");
                Response.Write(ex);
                Response.Write("<BR />");
            }
