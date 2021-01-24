    unit Main;
    
    interface
    
    uses
      Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
      Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;
    
    type
      TForm2 = class(TForm)
        Button2: TButton;
        Edit2: TEdit;
        procedure Button2Click(Sender: TObject);
      private
      public
      end;
      TStringCallback = procedure(str:PAnsiChar); cdecl;
    
      procedure strCallBack(fct: TStringCallback); cdecl; external 'csTest.dll';
    var
      Form2: TForm2;
    
    implementation
    
    {$R *.dfm}
    
    //*************************************************************
    //callback with string
    procedure writeEdit2(str: PAnsiChar); cdecl;
    begin
      Form2.Edit2.Text := str;
    end;
    
    procedure TForm2.Button2Click(Sender: TObject);
    begin
      strCallBack(writeEdit2);
    end;
    //*************************************************************
    
    end.
