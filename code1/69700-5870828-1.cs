      Image image = Image.FromFile(@"C:\Documents and Settings\someuser\Desktop\logoTop.gif");
      byte[] imageByte;
      using (MemoryStream ms = new MemoryStream())
      {
        image.Save(ms, ImageFormat.Gif);
        imageByte = ms.ToArray();
      }
      NHSession sessionManager = new NHSession();
      using (ISession session = sessionManager.GetSession())
      using (ITransaction tx = session.BeginTransaction())
        try
        {
          MyPhoto photo = new MyPhoto();
          photo.Photo = imageByte;
          session.Save(photo);
          session.Refresh(photo);
          Console.WriteLine(photo.EverifyPhotoId);
          tx.Commit();
        }
        catch (HibernateException)
        {
          if (tx.IsActive)
            tx.Rollback();
          throw;
        }
