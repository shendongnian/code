        public static int GetRadioSelection(this RadioButton rb, int Default = -1) {
            foreach(Control c in  rb.Parent.Controls) {
                RadioButton r = c as RadioButton;
                if(r != null && r.Checked) return Int32.Parse((string)r.Tag);
            }
            return Default;
        }
        public static bool IsRadioSelected(this RadioButton rb) {
            foreach(Control c in  rb.Parent.Controls) {
                RadioButton r = c as RadioButton;
                if(r != null && r.Checked) return true;
            }
            return false;
        }
