    public static void RetrieveConfigFiles(IDFStack idf) {
        using (var sshClient = new SshClient(idf.IPAddress, username, password)) {
            sshClient.Connect();
            using (var ssh = sshClient.CreateExtShellStream("dumb", 120, 80, 0, 0, 200000)) {
                ssh.DumpLines();
                ssh.DoCommand("no page");
                File.WriteAllLines(idf.ConfigPath, ssh.DoCommand("show running-config structured"));
                File.WriteAllLines(idf.StatusPath, ssh.DoCommand("show interfaces brief"));
                File.WriteAllLines(idf.LLDPPath, ssh.DoCommand("show lldp info remote-device detail"));
            }
            sshClient.Disconnect();
        }
    }
