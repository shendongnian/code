    // Create a secure version of the password
    SecureString pass = new SecureString();
    foreach ( char c in _pass.Text )
    {
       pass.AppendChar( c );
    }
    Process process = Process.Start( "PrivilegedProgram.exe", _arguments, _user.Text, pass, _domain.Text );
