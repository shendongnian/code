    private void GetRoom(string uri) 
    {
      var request = WebRequest.Create(uri);
      string text;
      var response = (HttpWebResponse)request.GetResponse();
      request.ContentType = "application/json; charset=utf-8";
      using(var sr = new StreamReader(response.GetResponseStream()))
      {
        text = sr.ReadToEnd();
        List<RoomConfigurationViewInfo> roomObject = JsonConvert.DeserializeObject < List<RoomConfigurationViewInfo>> (text);
        rooms.InnerHtml = "";
        for(int i=0; i < roomObject.Count; i++) 
        {
            string strOrganizer = roomObject[i].Organizer;
            string strSubject = roomObject[i].Subject;
            string strFrom = roomObject[i].From;
            string strTo = roomObject[i].To;
           
            rooms.InnerHtml += "<div class=\"card mb-4\">"
                             + "<div class=\"card-header text-center\">"
                             + "Room " + i + "";
                             + "</div>"
                             + "<div class=\"card-body\" style=\"background-color:#ff0000;color:white;\">"
                             + "<p>"
                             + "<asp:Literal Text=\"" + strOrganizer "\" runat=\"server\" ID=\"organiser_" + i + "\"/>"
                             + "<br />"
                             + "<label>" + strFrom + "</label>"
                             + "-"
                             + "<label>" + strTo + "</label>"
                             + "<br />"
                             + "<asp:Literal Text=\"" + strSubject + "\" runat=\"server\" ID=\"subject_" + i + "\" />"
                             + "</p>"
                             + "</div>"
                             + "</div>";
        }
      }
    }
