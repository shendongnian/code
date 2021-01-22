    private string getLocationByGeoLocation(string longitude, string latitude)
        {
            string locationName = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(longitude) || string.IsNullOrEmpty(latitude))
                    return "";
                string url = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false", latitude, longitude);
                WebRequest request = WebRequest.Create(url);
                using (WebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        DataSet dsResult = new DataSet();
                        dsResult.ReadXml(reader);
                        try
                        {
                            foreach (DataRow row in dsResult.Tables["result"].Rows)
                            {
                                string fullAddress = row["formatted_address"].ToString();
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            return locationName;
        }
