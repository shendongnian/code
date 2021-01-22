    class Student : IDisposable
    {
       private PictureClass studentPic;
       public void Dispose()
       {
          studentPic.Dispose();
       }
    }
