    class Foo : Form {
        private bool checkedProgrammatically = false;
    
        void someMethod() {
            // ...
            checkedProgrammatically = true;
            checkBox1.Checked = true;
            checkedProgrammatically = false;
            // ...
        }
    
        private void checkBox1_CheckChanged(object sender, EventArgs e) {
            if (checkedProgrammatically) return;
            // ...
        }
    }
