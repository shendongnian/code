    public class Utility {
        // This just sends the client a copy of the calling page itself
        public static void SendExcelFile(Page callingPage) {
            string path = callingPage.Request.PhysicalPath;
            callingPage.Response.AddHeader("Content-Disposition", "attachment;filename=test.xls");
            callingPage.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            callingPage.Response.AddHeader("Content-Length", new FileInfo(path).Length.ToString());
            callingPage.Response.TransmitFile(path);
        }
    }
