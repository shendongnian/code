    Process p = Process.Start(
        "makecert.exe",
        String.Join(" ", new string[] {
            "-r",//                     Create a self signed certificate
            "-pe",//                    Mark generated private key as exportable
            "-n", "CN=" + myHostName,// Certificate subject X500 name (eg: CN=Fred Dews)
            "-b", "01/01/2000",//       Start of the validity period; default to now.
            "-e", "01/01/2036",//       End of validity period; defaults to 2039
            "-eku",//                   Comma separated enhanced key usage OIDs
            "1.3.6.1.5.5.7.3.1," +//    Server Authentication (1.3.6.1.5.5.7.3.1)
            "1.3.6.1.5.5.7.3.2", //     Client Authentication (1.3.6.1.5.5.7.3.2)
            "-ss", "my",//              Subject's certificate store name that stores the output certificate
            "-sr", "LocalMachine",//    Subject's certificate store location.
            "-sky", "exchange",//       Subject key type <signature|exchange|<integer>>.
            "-sp",//                    Subject's CryptoAPI provider's name
            "Microsoft RSA SChannel Cryptographic Provider",
            "-sy", "12",//              Subject's CryptoAPI provider's type
            myHostName + ".cer"//       [outputCertificateFile]
        })
    );
