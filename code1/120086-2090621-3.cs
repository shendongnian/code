    using AjaxControlToolkit.HTMLEditor;
    namespace MyControls
    {
        public class CustomEditor : Editor
        {
            protected override void FillTopToolbar()
            {
                TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Bold());
            }
        }
    }
