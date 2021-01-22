    public partial class MyUserControl {
        private Form GetContainerForm {
            get {
                return this.FindForm();
            }
        }
        // And later on, where you need to set your TextBox's font:
        private void SetContainerInputFieldFont(Font f) {
            if (GetContainerForm == null) return; // Or throw, depending on what you need to do.
            ((MyMainForm)GetContainerForm).MyTextBoxFont = f
        }
    }
