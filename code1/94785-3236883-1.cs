      using SWF = System.Windows.Forms;
      using NUF = NUnit.Framework;
      namespace workshop.findControlTest {
         [NUF.TestFixture]
         public class FormTest {
            [NUF.Test]public void Find_menu() {
               // == prepare ==
               var fileTool = new SWF.ToolStripMenuItem();
               fileTool.Name = "fileTool";
               fileTool.Text = "File";
               var menuStrip = new SWF.MenuStrip();
               menuStrip.Items.Add(fileTool);
               var form = new SWF.Form();
               form.Controls.Add(menuStrip);
      
               // == execute ==
               var ctrl = form.Controls.Find("fileTool", true);
      
               // == not found! ==
               NUF.Assert.That(ctrl.Length, NUF.Is.EqualTo(0)); 
            }
         }
      }
