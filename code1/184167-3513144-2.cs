    class Student : IDisposable
    {
       private PictureClass studentPic;
       public void Dispose()
       {
          if (studentPic != null)
            studentPic.Dispose();
       }
       ...
    }
