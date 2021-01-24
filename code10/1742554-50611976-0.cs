    private async void button2_Click(object sender, EventArgs e) {
        var enbode = new Nethereum.Geth.Web3Geth("http://127.0.0.1:8545");
        var peers = await enbode.Admin.Peers.SendRequestAsync();
        richTextBox1.Text = peers.ToString();
        var peer = JsonConvert.DeserializeObject<Example>(richTextBox1.Text);
        dataGridView2.DataSource = new [] { peer };
    }
