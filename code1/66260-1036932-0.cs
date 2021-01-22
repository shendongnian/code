    static class Program {
        [System.STAThread]
        static void Main(string[] args) {
            System.Windows.Forms.MessageBox.Show(string.Join("|", args));
        }
    }
