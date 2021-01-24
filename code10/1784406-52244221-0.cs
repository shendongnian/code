    class Themes : Form
    {
        private readonly MainUI _main;
        public Themes(MainUI main) : this()
        {
            _main = main;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            _main.FireEvent();
        }
}
