    namespace WindowsFormsApp1
    {
        public partial class Settings : Form
        {
            Form1 frm = null;
            public Settings(Form1 frm)
            {
                this.frm = frm;
            }
            public void MethodWhereSwapPositionsGetsInvoked()
            {
                frm.SwapPositions();
            }
         }
    }
