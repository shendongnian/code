        var readings = new ArchG2.Portal.wmArchG201_Svc_fireWmdReading.wmdReading[] {
          new ArchG2.Portal.wmArchG201_Svc_fireWmdReading.wmdReading() {
            attrID = 1, created = DateTime.Now.AddDays(-1), reading = 17.34, userID = 2
          },
          new ArchG2.Portal.wmArchG201_Svc_fireWmdReading.wmdReading() {
            attrID = 2, created = DateTime.Now.AddDays(-2), reading = 99.76, userID = 3
          },
          new ArchG2.Portal.wmArchG201_Svc_fireWmdReading.wmdReading() {
            attrID = 3, created = DateTime.Now.AddDays(-5), reading = 82.17, userID = 4
          }
        };
        ArchG2.Portal.Utils.wmArchG201.Factory.DispatchInSsl3(ref flag, (ref string flag_inner) =>
        {
          // creates the binding, endpoint, etc. programatically to avoid mucking with
          // SharePoint web.config.
          var wsFireWmdReading = ArchG2.Portal.Utils.wmArchG201.Factory.Get_fireWmdReading(ref flag_inner, LH, Context);
          wsFireWmdReading.fireWmdReading(readings);
        });
