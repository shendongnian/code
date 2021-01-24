    Encoding encoding = Encoding.Default;
	string openSSLExe = "C:\\OpenSSL-Win32\\bin\\openssl.exe";
	string unencodedPsw = "something";
	string pkey = "MIIEvAIBADANB...";        //It comes from database, therefore needs to save each time.
	string pwdFile = Path.GetTempFileName();
	string rsaFile = Path.GetTempFileName();
	string outFile = Path.GetTempFileName();
	File.WriteAllBytes(pwdFile, encoding.GetBytes(unencodedPsw));
	File.WriteAllBytes(rsaFile,  encoding.GetBytes(pkey));
	string args = String.Format("pkeyutl -sign -in \"{0}\" -inkey \"{1}\" -out \"{2}\"", pwdFile, rsaFile, outFile);
	var proc = new Process
	{
		StartInfo = new ProcessStartInfo
		{
			FileName = openSSLExe,
			Arguments = args,
			UseShellExecute = false,
			RedirectStandardOutput = true,
			CreateNoWindow = true
		}
	};
	proc.Start();
	proc.WaitForExit();
	string encodedPsw = Convert.ToBase64String(File.ReadAllBytes(outFile));
	File.Delete(pwdFile);
	File.Delete(rsaFile);
	File.Delete(outFile);
	return encodedPsw;
