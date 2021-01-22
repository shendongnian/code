delphi
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
Quite interesting. I no longer use Delphi, but I recall being able to very easily create different types of controls on a custom designer canvas using the metaclass feature: the control class, eg. TButton, TTextBox etc. was a parameter, and I could call the appropriate constructor using the actual metaclass argument. 
Kind of the poor man's factory pattern :)
