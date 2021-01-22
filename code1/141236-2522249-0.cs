            SecureString ss = new SecureString();
            ss.AppendChar('X');
            // other calls to AppendChar
            ProcessStartInfo psi = new ProcessStartInfo() {
                UserName = "XXX", Password = ss, Domain = "XXX",
                  UseShellExecute = false,
                  FileName = "mmc", Arguments = "services.msc"
              };
            Process.Start(psi);
