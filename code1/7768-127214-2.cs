    public class HelloWorldCommand : ToolStripItemCommand
    {
        #region Overrides of ControlCommand
        protected override void Execute()
        {
            MessageBox.Show("Hello World");
        }
        #endregion
    }
