    var view_query_1 = from i in DbContext.myEntities.Local
                     select new GetFreeDevices
                     {
                         MArticleNumber = i.ArticleNumber,
                         MFirmware = i.Firmware,
                         MGroup = i.Group,
                         MName = i.Name,
                         MSoftware = i.SoftwareVersion,
                         SA = GetNumberOfDevices(i.ArticleNumber,2),   //
                         STH = GetNumberOfDevices(i.ArticleNumber,3),  // These are now ok!
                         SASTH = GetNumberOfDevices(i.ArticleNumber,7) //
                     };
        return PartialView(view_query_1.AsEnumerable());
