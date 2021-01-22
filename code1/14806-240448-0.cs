            WebSysDataContext db = new WebSysDataContext(Contexts.WEBSYS_CONN());
            var GetFile = from x in db.BinaryStores
                          where x.BinaryID == "1"
                          select x.BinaryFile;
            FileStream MyFileStream;
            long FileSize;
            MyFileStream = new FileStream(GetFile, FileMode.Open);
            FileSize = MyFileStream.Length;
            byte[] Buffer = new byte[(int)FileSize];
            MyFileStream.Read(Buffer, 0, (int)FileSize);
            MyFileStream.Close();
            Response.Write("<b>File Contents: </b>");
            Response.BinaryWrite(Buffer);
            
        }
