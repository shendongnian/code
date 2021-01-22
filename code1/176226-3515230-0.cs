    objMIMEType = Microsoft.Win32.Registry.GetValue("HKEY_CLASSES_ROOT\\." + objAttachment.Extension, "Content Type", "application/octetstream");
            if (objMIMEType != null)
                strMIMEType = objMIMEType.ToString();
            else
            {
                strMIMEType = "application/octetstream";
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + objAttachment.FullFileName);
                context.Response.AddHeader("Content-Length", objAttachment.AttachmentData.Length.ToString());
            }
