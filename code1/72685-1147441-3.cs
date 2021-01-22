    private void btnAddServer_Click(object sender, EventArgs e)
    {
        string ipAdd;
        using(Input form = new Input())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                //Create a property in SetIPAddressForm to return the input of user.
                ipAdd = form.IPAddress;
            }
        }
    }
