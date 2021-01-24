            Response.Clear();
            Response.AddHeader("", "");
            Response.Charset = System.Text.UTF8Encoding.UTF8.WebName;
            Response.AddHeader("content-disposition", "attachment;  filename="MyFile.xlsx");
            Response.ContentType = "application/text";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            controller.HttpContext.Response.BinaryWrite(xlPackage.GetAsByteArray());
            controller.HttpContext.Response.End();
