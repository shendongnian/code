    type
      TForm1 = class(TForm)
        procedure FormShow(Sender: TObject);
      end;
      TTestClass = class
      public
        class procedure TestMethod(); virtual;
      end;
      TTestDerivedClass = class(TTestClass)
      public
        class procedure TestMethod(); override;
      end;
      TTestMetaClass = class of TTestClass;
    var
      Form1: TForm1;
    implementation
    {$R *.dfm}
    class procedure TTestClass.TestMethod();
    begin
      Application.MessageBox('base', 'Message');
    end;
    class procedure TTestDerivedClass.TestMethod();
    begin
      Application.MessageBox('descendant', 'Message');
    end;
    procedure TForm1.FormShow(Sender: TObject);
    var
      sample: TTestMetaClass;
    begin
      sample := TTestClass;
      sample.TestMethod;
      sample := TTestDerivedClass;
      sample.TestMethod;
    end;
