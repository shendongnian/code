    public class ClientForm : Form
    {
        public ClientForm() { }
    }
    public class ClientStatusForm : Form
    {
        ClientForm _parent;
        public ClientStatusForm(ClientForm parent)
        {
            _parent = parent;
        }
    }
