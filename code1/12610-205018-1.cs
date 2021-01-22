    procedure TfrmMain.SynchLocalTimeWithServer;
    var
      tod : TTimeHandler;
    begin
      tod := TTimeHandler.Create(cboServerName.Text);
      try
        tod.SetLocalSystemTime(tod.RemoteSystemTime);
      finally
        FreeAndNil(tod);
      end;  //try-finally
    end;
