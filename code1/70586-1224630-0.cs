    // This is the way WTSApi32.dll checks if Terminal Service is running
    function IsTerminalServiceRunning: boolean;
    var hSCM: HANDLE;
      hService: HANDLE;
      ServiceStatus: SERVICE_STATUS;
    begin
      Result := False;
      // Open handle to Service Control Manager
      hSCM := OpenSCManager(nil, SERVICES_ACTIVE_DATABASE, GENERIC_READ);
      if hSCM > 0 then
      begin
        // Open handle to Terminal Server Service
        hService := OpenService(hSCM, 'TermService', GENERIC_READ);
        if hService > 0 then
        begin
          // Check if the service is running
          QueryServiceStatus(hService, ServiceStatus);
          Result := ServiceStatus.dwCurrentState = SERVICE_RUNNING;
          // Close the handle
          CloseServiceHandle(hService);
        end;
        // Close the handle
        CloseServiceHandle(hSCM);
      end;
    end;
    // This the way QWinsta.exe checks if Terminal Services is active:
    function AreWeRunningTerminalServices: Boolean;
    var VersionInfo: TOSVersionInfoEx;
      dwlConditionMask: Int64;
    begin
      // Zero Memory and set structure size
      ZeroMemory(@VersionInfo, SizeOf(VersionInfo));
      VersionInfo.dwOSVersionInfoSize := SizeOf(VersionInfo);
    
      // We are either Terminal Server or Personal Terminal Server
      VersionInfo.wSuiteMask := VER_SUITE_TERMINAL or VER_SUITE_SINGLEUSERTS;
      dwlConditionMask := VerSetConditionMask(0, VER_SUITENAME, VER_OR);
    
      // Test it
      Result := VerifyVersionInfo(VersionInfo, VER_SUITENAME, dwlConditionMask);
    end;
