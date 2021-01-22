    class Client
    {
        private string workPhone; // this could still be a public property if desired
        public readonly Property<string> WorkPhone; // this could be created outside Client if using a regular public property
        public int AreaCode { get; set; }
        public Client() {
            WorkPhone = new Property<string>(
                delegate () { return workPhone; },
                delegate (string value) { workPhone = value; });
        }
    }
    class Usage
    {
        public void PrependAreaCode(Property<string> phone, int areaCode) {
            phone.Value = areaCode.ToString() + "-" + phone.Value;
        }
        public void PrepareClientInfo(Client client) {
            PrependAreaCode(client.WorkPhone, client.AreaCode);
        }
    }
