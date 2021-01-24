            public static void Test()
        {
            var doc = AcAp.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            using (var tr = db.TransactionManager.StartTransaction())
            {
                var ms = db.GetModelSpace(OpenMode.ForWrite);
                var mt = ms.AddMtext(Point3d.Origin, AttachmentPoint.TopLeft, "foobar", 2.5);
                // do what you want with 'mt'
                tr.Commit();
            }
        }
