using System.Windows.Forms;
using System.Windows.Forms.Design;
namespace YourNameSpace
{
    class CustomFileBrowser : FileNameEditor
    {
        protected override void InitializeDialog(OpenFileDialog openFileDialog)
        {
            base.InitializeDialog(openFileDialog);
            openFileDialog.Title = "Select Project File : ";
            openFileDialog.Filter = "Project File (*.proj)|*.proj"; ;
        }
    }
}
**Usage :**
            [Category("Settings"), DisplayName("Project File:")]
            [EditorAttribute(typeof(CustomFileBrowser), typeof(System.Drawing.Design.UITypeEditor))]
            public string Project_File { get; set; }
