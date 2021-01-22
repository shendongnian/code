    class Foo
    {
          [Common.DisplayNameLocalized(typeof(Resources.Resource), "CreationDateDisplayName"),
          Common.DescriptionLocalized(typeof(Resources.Resource), "CreationDateDescription")]
          public DateTime CreationDate
          {
             get;
             set;
          }
    }
