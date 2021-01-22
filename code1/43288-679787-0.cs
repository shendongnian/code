    clas MyTextbox...
    {
       public MyTextbox()
       {
          // it defaults itself from its own read-only font "new" object instance and works
          base.Font = Font;
       }
    }
