    static class ExtensionMethods
    {
        public static BlockTableRecord GetModelSpace(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            var tr = db.TransactionManager.TopTransaction;
            if (tr == null)
                throw new Autodesk.AutoCAD.Runtime.Exception(ErrorStatus.NoActiveTransactions);
            return (BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(db), mode);
        }
        public static void Add(this BlockTableRecord btr, Entity entity)
        {
            var tr = btr.Database.TransactionManager.TopTransaction;
            if (tr == null)
                throw new Autodesk.AutoCAD.Runtime.Exception(ErrorStatus.NoActiveTransactions);
            btr.AppendEntity(entity);
            tr.AddNewlyCreatedDBObject(entity, true);
        }
        public static MText AddMtext(this BlockTableRecord btr, 
            Point3d location, 
            AttachmentPoint attachmentpoint, 
            string contents, 
            double height, 
            short color = 256, 
            bool usebackgroundmask = false, 
            bool usebackgroundcolor = false, 
            double backgroundscale = 1.5)
        {
            MText mt = new MText();
            mt.SetDatabaseDefaults();
            mt.Location = location;
            mt.Attachment = attachmentpoint;
            mt.Contents = contents;
            mt.Height = height;
            mt.ColorIndex = color;
            mt.BackgroundFill = usebackgroundmask;
            mt.UseBackgroundColor = usebackgroundcolor;
            mt.BackgroundScaleFactor = backgroundscale;
            btr.Add(mt);
            return mt;
        }
    }
