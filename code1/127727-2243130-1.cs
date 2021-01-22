    using DhcpObjects;
    class Program {
        static void Main(string[] args) {
            var manager = new Manager();
            var server = dhcpmgr.Servers.Connect("1.2.3.4");
            // query server here
        }
    }
