            DateTime from;
            DateTime to;
            DateTime.TryParse(TempData["fromDTTM"].ToString(),out from);
            DateTime.TryParse(TempData["toDTTM"].ToString(),out to);
            from = from == DateTime.MinValue ? DateTime.Today : from;
            to = to == DateTime.MinValue ? DateTime.Today : to;
            List<pGetMailsSentReportWithoutPageResult> allUsers;
            var users = _profileService.GetMailSenderReportWithoutPage(from, to);
            allUsers = users.ToList<pGetMailsSentReportWithoutPageResult>();
            Response.AddHeader("Content-Disposition", "filename=MailSent-" + TempData["fromDTTM"].ToString()+"-to-"+TempData["toDTTM"].ToString()+ ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
            Response.Write("<head>");
            Response.Write("<meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\">");
            Response.Write("<!--[if gte mso 9]>");
            Response.Write("<xml>");
            Response.Write("<x:ExcelWorkbook>");
            Response.Write("<x:ExcelWorksheets>");
            Response.Write("<x:ExcelWorksheet>");
            Response.Write("<x:WorksheetOptions>");
            //these 2 lines draw the gridlines into the Excelsheet
            Response.Write("<x:Panes>");
            Response.Write("</x:Panes>");
            Response.Write("</x:WorksheetOptions>");
            Response.Write("</x:ExcelWorksheet>");
            Response.Write("</x:ExcelWorksheets>");
            Response.Write("</x:ExcelWorkbook>");
            Response.Write("</xml>");
            Response.Write("<![endif]-->");
            Response.Write("</head>");
            Response.Write("<body>");
            Response.Write("<table>");
            Response.Write("<tr>  <th>  Recipient Name  </th> <th> E-Mail </th> <th> Subject </th> <th> Date </th> </tr>");
            foreach (var user in allUsers)
            {
                Response.Write("<tr>  <td>" + user.PersonName.ToString() + "</td>");
                Response.Write("<td>" + user.ToAddress.ToString() + " </td>");
                Response.Write("<td>" + user.Subject.ToString() + "</td>");
                Response.Write("<td>" + user.CWhen.ToString() + "</td> </tr>");
            }
            Response.Write("</table>");
            Response.End();
            return View("MailSentReport");
        } 
