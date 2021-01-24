        public static void Test()
        {
            var doc = AcAp.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            using (var tr = db.TransactionManager.StartTransaction())
            {
                var mt = db.GetModelSpace().AddMtext(Point3d.Origin, AttachmentPoint.TopLeft, "foobar", 2.5);
                tr.Commit();
            }
        }
