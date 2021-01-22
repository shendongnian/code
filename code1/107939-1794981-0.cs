    var aPhone = MyPhone.Create;
      MyPhone.Create.IncludeApps
      (
        x =>
          {
            x.IncludeAppFor(new object());
          }
      );
    class MyPhone
      {
        public MyPhone IncludeApps(Action<MyPhone> includeCommand)
        {
            includeCommand.Invoke(this);
            return this;
        }
      }
