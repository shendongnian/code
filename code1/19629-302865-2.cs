    private void button1_Click(object sender, EventArgs e) {
      using (new HourGlass()) {
        System.Threading.Thread.Sleep(3000);
      }
    }
